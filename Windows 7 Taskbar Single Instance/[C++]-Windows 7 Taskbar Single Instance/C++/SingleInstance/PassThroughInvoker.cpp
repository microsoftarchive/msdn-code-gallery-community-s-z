#include "stdafx.h"
#include "PassThroughInvoker.h"

void PassThroughInvoker::Invoke(PFNARGSHANDLER pHandlerToInvoke, LPCWSTR *pArgs, DWORD dwLength, LPVOID pContext)
{
	pHandlerToInvoke(pArgs, dwLength, pContext);
}