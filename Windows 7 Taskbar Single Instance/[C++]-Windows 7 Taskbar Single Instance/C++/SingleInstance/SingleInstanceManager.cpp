#include "stdafx.h"
#include "SingleInstanceManager.h"
#include "PassThroughInvoker.h"
#include "NamedPipeStrategyFactory.h"
#include "Utilities.h"
#include "SingleInstanceManagerException.h"
#include <memory>
#include <wchar.h>
#include <crtdbg.h>
#include <shellapi.h>

#define BUFFER_SIZE 32767

const SingleInstanceManager *SingleInstanceManager::Initialize(const SingleInstanceManagerSetup &setup)
{
	const DeliveryStrategyFactory *pFactory = setup.GetStrategyFactory();
	std::auto_ptr<const DeliveryStrategyFactory> apFactory;
	if (pFactory == NULL)
	{
		apFactory.reset(new NamedPipeStrategyFactory());
		pFactory = apFactory.get();
	}

	WCHAR bufUserLocalId[BUFFER_SIZE];
	GenerateUserLocalId(setup.GetApplicationId(), bufUserLocalId, BUFFER_SIZE);

    // Initialize the SingleInstanceManager instance
	std::auto_ptr<SingleInstanceManager> apManager(new SingleInstanceManager(bufUserLocalId, setup.GetArgsHandler(), setup.GetArgsHandlerContext(),
		pFactory->CreateStrategy(), setup.GetArgsProvider(), setup.GetHandlerInvoker(), setup.GetInstanceNotificationOption(),
		setup.GetDeliveryFailureNotification()));

	if (! apManager->TryEnsureFirstInstance())
	{
        // If this is not the first application instance (another instance is already running) then we need to exit/throw
		switch (setup.GetTerminationOption())
		{
			case TerminationOption_Exit:
				ExitProcess(setup.GetExitCode());  // Make sure this is the write way to exit
			case TerminationOption_Throw:
				throw SingleInstanceManagerException("Application Instance Already Exists!");
			default:
				_ASSERT_EXPR(FALSE, L"Should never be here!");
				throw SingleInstanceManagerException("Should never be here!");
		}
	}
	return apManager.release();
}

SingleInstanceManager::SingleInstanceManager(LPCWSTR lpApplicationId, PFNARGSHANDLER pfnArgumentsHandler, LPVOID pContext, ArgumentsDeliveryStrategy *pStrategy, 
	PFNARGSPROVIDER pfnArgumentsProvider, ArgumentsHandlerInvoker *pHandlerInvoker, InstanceNotificationOption inoNotification,
	PFNFAILURENOTIFICATION pfnDeliveryFailureNotification)
{
	m_lpApplicationId = lpApplicationId;
	m_pfnArgumentsHandler = pfnArgumentsHandler;
	m_pContext = pContext;
	m_pStrategy = pStrategy;
	m_pfnArgumentsProvider = pfnArgumentsProvider != NULL ? pfnArgumentsProvider : DefaultArgumentsProvider;
	m_pHandlerInvoker = pHandlerInvoker != NULL ? pHandlerInvoker : new PassThroughInvoker();
	m_inoNotification = inoNotification;
	m_pfnDeliveryFailureNotification = pfnDeliveryFailureNotification;

	m_hMutex = NULL;
}

SingleInstanceManager::~SingleInstanceManager()
{
	if (m_hMutex != NULL)
	{
		CloseHandle(m_hMutex);
	}
	delete m_pStrategy;
}

const DeliveryStrategyFactory *SingleInstanceManager::GetDefaultFactory()
{
	return new NamedPipeStrategyFactory();
}

void SingleInstanceManager::GenerateUserLocalId(LPCWSTR lpApplicationId, LPWSTR lpBuffer, DWORD dwLength)
{
	DWORD dwBytesCopied = dwLength;
	if(! GetUserNameW(lpBuffer, &dwBytesCopied))
		throw SingleInstanceManagerException("Error getting user name.");
	swprintf(&lpBuffer[dwBytesCopied-1], dwLength - dwBytesCopied + 1, L":%s", lpApplicationId);
}

BOOL SingleInstanceManager::TryEnsureFirstInstance()
{
	if (IsFirstApplicationInstance())
	{
		m_pStrategy->InitializeFirstInstance(m_lpApplicationId, &SingleInstanceManager::NotifyArgumentsReceivedStatic, this);
		return TRUE;
	}
	else
	{
		try
		{
            // There is another instance running and we must notify it
            // with the command line arguments.
			int nNumOfArgs;
			LPWSTR *pArgs = m_pfnArgumentsProvider(m_lpApplicationId, &nNumOfArgs);
			m_pStrategy->DeliverArgumentsToFirstInstance(m_lpApplicationId, pArgs, nNumOfArgs);
			LocalFree(pArgs);
		}
		catch (SingleInstanceManagerException& ex)
		{
			if (m_pfnDeliveryFailureNotification != NULL)
				m_pfnDeliveryFailureNotification(ex);
		}
		return FALSE;
	}
}

BOOL SingleInstanceManager::IsFirstApplicationInstance()
{
	_ASSERT_EXPR(m_hMutex == NULL, L"Mutex has already been initialized by this instance!");

	m_hMutex = CreateMutex(NULL, TRUE, m_lpApplicationId);
	if (m_hMutex == NULL)
		throw SingleInstanceManagerException("Error creating mutex used for single instance ensurence!");
	return (GetLastError() != ERROR_ALREADY_EXISTS);
}

void SingleInstanceManager::NotifyArgumentsReceivedStatic(LPCWSTR *pArguments, DWORD dwLength, BOOL remoteIsAdmin, LPVOID pContext)
{
	SingleInstanceManager *pManager = (SingleInstanceManager *)pContext;

	// NOTE: The context which was used so far is the internal context
	// which facilitates subscribing SIM's static function (this function) as a callback for the strategy
	// The instance method will pass on the user's context
	pManager->NotifyArgumentsReceived(pArguments, dwLength, remoteIsAdmin);
}

void SingleInstanceManager::NotifyArgumentsReceived(LPCWSTR *pArguments, DWORD dwLength, BOOL bRemoteIsAdmin)
{
	if (m_inoNotification == InstanceNotificationOption_NotifyOnlyIfAdmin)
	{
		if (IsUserAdmin() && !bRemoteIsAdmin)
			return;
	}
	
	if (m_pfnArgumentsHandler != NULL)
		m_pHandlerInvoker->Invoke(m_pfnArgumentsHandler, pArguments, dwLength, m_pContext);
}

LPWSTR *SingleInstanceManager::DefaultArgumentsProvider(LPCWSTR lpApplicationId, int *pnNumOfArgs)
{
	LPWSTR pCmdLineStr = GetCommandLineW();
	return CommandLineToArgvW(pCmdLineStr, pnNumOfArgs);
}

