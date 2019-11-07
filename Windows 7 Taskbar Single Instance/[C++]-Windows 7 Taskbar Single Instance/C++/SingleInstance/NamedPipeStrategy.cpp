#include "stdafx.h"
#include "SingleInstanceManagerException.h"
#include "NamedPipeStrategy.h"
#include "Utilities.h"
#include <process.h>
#include <stdio.h>
#include <strsafe.h>
#include <SDDL.h>
#include <crtdbg.h>

#define BUFSIZE 512
#define MAX_COMMAND_LINE_LENGTH 32767
#define PIPE_CLIENT_CONNECT_TIMEOUT 5000

// DACL: Allow, generic all, SYSTEM
// DACL: Allow, generic all, %s (account SID)
// DACL: Deny,  generic all, network logon
// SACL: Mandatory level medium
#define NAMED_PIPE_SDDL L"D:(A;;GA;;;SY)(A;;GA;;;%s)(D;;GA;;;NU)S:(ML;;NW;;;ME)"

NamedPipeStrategy::NamedPipeStrategy()
	: m_hReceiverThread(NULL),
	  m_hReceiverTerminationEvent(NULL),
	  m_hPipe(NULL),
	  m_bRunLoop(NULL)
{
}

void NamedPipeStrategy::OnInitializeFirstInstance(LPCWSTR lpApplicationId)
{
	// Create pipe
	m_hPipe = CreatePipe(lpApplicationId, true);
	
	m_hReceiverTerminationEvent = CreateEvent(NULL, TRUE, FALSE, NULL);
	if (m_hReceiverTerminationEvent == NULL)
	{
		CloseHandle(m_hPipe); // can't do anything if CloseHandle returns false
		m_hPipe = NULL;
		m_bRunLoop = FALSE;
		throw SingleInstanceManagerException("Error creating receiver thread termination event");
	}

	// Create receiver thread
	InitOverlapped();
	m_bRunLoop = TRUE;
	m_hReceiverThread = (HANDLE) _beginthreadex(0, 0, RecieveThreadStatic, this, 0, NULL);
	if (m_hReceiverThread == NULL)
	{
		CloseOverlapped();
		CloseHandle(m_hPipe); // can't do anything if CloseHandle returns false
		CloseHandle(m_hReceiverTerminationEvent); 
		m_hPipe = NULL;
		m_bRunLoop = FALSE;
		m_hReceiverTerminationEvent = NULL;
		throw SingleInstanceManagerException("Error creating receiver thread.");
	}
}

void NamedPipeStrategy::OnDeliverArgumentsToFirstInstance(LPCWSTR lpApplicationId, LPWSTR *pArgs, DWORD dwLength)
{
	// Prepare command argument buffer by concatenating all arguments into a contiguous buffer,
	// and placing a NULL caracter after every argument:
	// [Arg0][NULL][Arg1][NULL]...

	// Calculate argument buffer length
	size_t argBufferLength = 0;
	size_t *argLengths = new size_t[dwLength];
	for (size_t i = 0; i < dwLength; i++)
	{
		size_t argLen = wcslen(pArgs[i]) + 1; // + 1 for the NULL terminator
		argLengths[i] = argLen;
		argBufferLength += argLen;
	}

	if (argBufferLength == 0)
		argBufferLength = 1; // ensure at least a single NULL terminator

	LPWSTR lpArgBufferBase = new WCHAR[argBufferLength];
	memset(lpArgBufferBase, 0, sizeof(WCHAR) * argBufferLength);
	LPWSTR lpArgBufferPtr = lpArgBufferBase;

	for (size_t i = 0; i < dwLength; i++)
	{
		wcscpy_s(lpArgBufferPtr, argBufferLength - (lpArgBufferPtr - lpArgBufferBase), pArgs[i]);
		lpArgBufferPtr += argLengths[i];
	}

	lpArgBufferBase[argBufferLength - 1] = L'\0';
	delete[] argLengths;

	HANDLE hClientPipe = CreatePipe(lpApplicationId, false);

	DWORD dwWritten;
	if (!WriteFile(hClientPipe, lpArgBufferBase, argBufferLength * sizeof(WCHAR), &dwWritten, NULL) ||
		dwWritten != argBufferLength * sizeof(WCHAR))
	{
		delete[] lpArgBufferBase;
		CloseHandle(hClientPipe);
		throw SingleInstanceManagerException("Error writing to the named pipe.");
	}


	delete[] lpArgBufferBase;
	CloseHandle(hClientPipe);
}

NamedPipeStrategy::~NamedPipeStrategy()
{
	// Cleanup thread
	m_bRunLoop = FALSE; // tell thread to shutdown gracefully	
	if (m_hReceiverThread != NULL)
	{
		if (m_hReceiverTerminationEvent != NULL)
			SetEvent(m_hReceiverTerminationEvent);

		WaitForSingleObject(m_hReceiverThread, INFINITE);
		CloseHandle(m_hReceiverThread);
		m_hReceiverThread = NULL;
	}

	if (m_hReceiverTerminationEvent != NULL)
	{
		CloseHandle(m_hReceiverTerminationEvent);
		m_hReceiverTerminationEvent = NULL;
	}

	// Cleanup pipe
	if (m_hPipe != NULL)
	{
		CloseHandle(m_hPipe);
		m_hPipe = NULL;
	}

	CloseOverlapped();
}

BOOL NamedPipeStrategy::GetSecurityAttrsMediumIL(LPSECURITY_ATTRIBUTES secAttrs)
{
	HANDLE hProcessToken = NULL;

	int tokenInfoBufferSize = 256;
	TOKEN_USER *pTokenUserInfo = (TOKEN_USER *) new char[tokenInfoBufferSize];


	int sddlBufferSizeInChars = 256;
	LPWSTR pSDDLStr = new WCHAR[sddlBufferSizeInChars];

	LPWSTR pProcessSidString = NULL;
	PSECURITY_DESCRIPTOR secDescr = NULL;

	__try
	{	
		if (!OpenProcessToken(GetCurrentProcess(), TOKEN_QUERY, &hProcessToken))
		{
			return FALSE;
		}

		DWORD dwBytesNeededForTokenBuffer;
		if (!GetTokenInformation(hProcessToken, TokenUser, pTokenUserInfo, tokenInfoBufferSize, &dwBytesNeededForTokenBuffer))
		{
			return FALSE;
		}

		if (!ConvertSidToStringSid(pTokenUserInfo->User.Sid, &pProcessSidString))
		{
			return FALSE;
		}
		
		HRESULT hr = StringCchPrintfW(pSDDLStr, sddlBufferSizeInChars, NAMED_PIPE_SDDL,
			pProcessSidString);

		if (FAILED(hr))
		{
			return FALSE;
		}

		if (!ConvertStringSecurityDescriptorToSecurityDescriptorW(pSDDLStr, SDDL_REVISION_1, &secDescr, NULL))
		{
			return FALSE;
		}
		
		secAttrs->bInheritHandle = FALSE;
		secAttrs->nLength = sizeof(SECURITY_ATTRIBUTES);
		secAttrs->lpSecurityDescriptor = secDescr;
		return TRUE;
	}
	__finally
	{
		if (hProcessToken != NULL)
			CloseHandle(hProcessToken);
		
		delete[] pTokenUserInfo;
		delete[] pSDDLStr;

		if (pProcessSidString != NULL)
			LocalFree(pProcessSidString);
	}
}

HANDLE NamedPipeStrategy::CreatePipe(LPCWSTR lpApplicationId, bool bCreateServerPipe)
{
	size_t appIdSizeInChars = wcslen(lpApplicationId);
	if (lpApplicationId == NULL || appIdSizeInChars == 0)
		throw SingleInstanceManagerException("lpApplicationId must not be NULL or empty");

	size_t bufferSizeInChars = appIdSizeInChars + 10; // +10 for the prefix and for the NULL terminator
	LPWSTR pPipeName = new WCHAR[bufferSizeInChars];
	HRESULT hr = StringCchPrintfW(pPipeName, bufferSizeInChars, L"\\\\.\\pipe\\%s", lpApplicationId);
	if (FAILED(hr))
	{
		delete[] pPipeName;
		throw SingleInstanceManagerException("Error formatting named pipe name string");
	}
	
	HANDLE hPipe = INVALID_HANDLE_VALUE;

	if (bCreateServerPipe)
	{	
		SECURITY_ATTRIBUTES secAttrs;	
		if (!GetSecurityAttrsMediumIL(&secAttrs))
		{
			delete[] pPipeName;
			throw SingleInstanceManagerException("Error generating security descriptor for named pipe");
		}

		// Create a new named pipe
		hPipe = CreateNamedPipe(
			pPipeName, 
			PIPE_ACCESS_INBOUND | FILE_FLAG_OVERLAPPED, 
			PIPE_TYPE_MESSAGE | PIPE_READMODE_MESSAGE | PIPE_WAIT,
			1,
			BUFSIZE,
			BUFSIZE,
			0,
			&secAttrs);

		LocalFree(secAttrs.lpSecurityDescriptor);		
	}
	else
	{
		// Open and existing pipe
		hPipe = CreateFile( 
			pPipeName,
			GENERIC_WRITE, 
			0,
			NULL,
			OPEN_EXISTING,
			0,
			NULL);

		if (GetLastError() == ERROR_PIPE_BUSY)
		{
			if (!WaitNamedPipe(pPipeName, PIPE_CLIENT_CONNECT_TIMEOUT))
			{
				delete[] pPipeName;
				throw SingleInstanceManagerException("Timed out waiting for busy server named pipe");
			}
		}
	}

	delete[] pPipeName;
	
	if (hPipe == INVALID_HANDLE_VALUE)
		throw SingleInstanceManagerException("Error opening/creating named pipe.");

	return hPipe;
}

void NamedPipeStrategy::InitOverlapped()
{
	memset(&m_ov, 0, sizeof(m_ov));
	m_ov.hEvent = CreateEvent(NULL, TRUE, FALSE, NULL);

	if (m_ov.hEvent == NULL)
	{
		throw SingleInstanceManagerException("Error creating pipe overlapped event");
	}
}

void NamedPipeStrategy::CloseOverlapped()
{
	if (m_ov.hEvent != NULL)
	{
		CloseHandle(m_ov.hEvent);  // Nothing to do about a returned FALSE
		m_ov.hEvent = NULL;
	}
}

DWORD NamedPipeStrategy::ReceiveThread()
{
	LPWSTR pCommandArgs = new WCHAR[MAX_COMMAND_LINE_LENGTH];
	DWORD returnErr = 0;
	HANDLE rEvents[2] = {m_ov.hEvent, m_hReceiverTerminationEvent};

	while (m_bRunLoop)
	{
		if (!ConnectNamedPipe(m_hPipe, &m_ov))
		{
			if (GetLastError() != ERROR_PIPE_CONNECTED && GetLastError() != ERROR_IO_PENDING)
			{
				returnErr = 1;
				break;
			}
		}

		DWORD waitResult = WaitForMultipleObjects(2, rEvents, FALSE, INFINITE);
		if (waitResult == WAIT_OBJECT_0)
		{
			DWORD dwWritten;
			if (!GetOverlappedResult(m_hPipe, &m_ov, &dwWritten, FALSE))
			{				
				if (GetLastError() != ERROR_PIPE_CONNECTED)
				{
					returnErr = 1;
					break;
				}
			}
		}
		else if (waitResult == WAIT_OBJECT_0 + 1)
		{
			// Graceful shutdown
			break;
		}
	
		// When we get here the client is connected
		WCHAR pCommandArgs[MAX_COMMAND_LINE_LENGTH];
		DWORD dwBytesRead;
		// Since we are using Message Mode, one read is sufficient to get all arguments
		if (!ReadFile(m_hPipe, pCommandArgs, MAX_COMMAND_LINE_LENGTH * sizeof(WCHAR), &dwBytesRead, NULL))
		{
			DisconnectNamedPipe(m_hPipe);
			continue;
		}

		// Check if client side is admin
		ImpersonateNamedPipeClient(m_hPipe);
		BOOL bClientIsAdmin = IsUserAdmin();
		RevertToSelf();

		// after the message has been received, disconnect and continue listening for the next client
		DisconnectNamedPipe(m_hPipe);

		// Re-construct the string array from the buffer		
		if (dwBytesRead == 0 || dwBytesRead % sizeof(WCHAR) != 0) // must be non-zero and even length
			continue;

		int charCount = dwBytesRead / sizeof(WCHAR);

		// Force the least byte read to be NULL terminated. It should already be transmitted like this at the client side
		pCommandArgs[charCount - 1] = '\0';

		int argc = 0;
		int charsRead = 0;
		LPCWSTR *pCommandArgsArr = new LPCWSTR[MAX_COMMAND_LINE_LENGTH];
		memset(pCommandArgsArr, 0, MAX_COMMAND_LINE_LENGTH * sizeof(LPWSTR));

		while (charsRead < charCount)
		{
			size_t argLen = wcslen(pCommandArgs + charsRead);
			if (argLen > 0)
			{
				LPWSTR pArg = new WCHAR[argLen + 1];
				wcscpy_s(pArg, argLen + 1, pCommandArgs + charsRead);
				pCommandArgsArr[argc] = pArg;
				argc++;
				charsRead += (argLen + 1);
			}
		}

		NotifyArgumentsReceived(pCommandArgsArr, argc, bClientIsAdmin);

		for (int i = 0; pCommandArgsArr[i] != NULL; i++)
		{
			delete[] pCommandArgsArr[i];
		}

		delete[] pCommandArgsArr;
	}

	delete[] pCommandArgs;
	return returnErr;
}

unsigned int WINAPI NamedPipeStrategy::RecieveThreadStatic(void *lpvHandlePipe)
{
	NamedPipeStrategy *pStrategy = reinterpret_cast<NamedPipeStrategy *>(lpvHandlePipe);
	return pStrategy->ReceiveThread();
}
