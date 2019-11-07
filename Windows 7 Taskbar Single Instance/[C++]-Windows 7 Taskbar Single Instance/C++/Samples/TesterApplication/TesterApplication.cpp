// TesterApplication.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "SingleInstanceManager.h"

const SingleInstanceManager *g_SIM;

void ArgsHandler(LPCWSTR* pArguments, DWORD dwLength, LPVOID pContext)
{
	wprintf(L"Got %u args.\n", dwLength);

	for (unsigned int i = 0; i < dwLength; i++)
	{
		wprintf(L"Argument %u: %s\n", i, pArguments[i]);
	}
}

int _tmain(int argc, _TCHAR* argv[])
{
	SingleInstanceManagerSetup simSetup(L"MyApp", ArgsHandler, NULL);
	g_SIM = SingleInstanceManager::Initialize(simSetup);

	getchar();

	delete g_SIM;

	return 0;
}

