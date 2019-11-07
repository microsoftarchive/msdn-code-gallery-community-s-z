#pragma once

#include <windows.h>
#include "SingleInstanceManagerException.h"

typedef void (*PFNARGSHANDLER)(LPCWSTR* pArguments, DWORD dwLength, LPVOID pContext);
typedef LPWSTR *(*PFNARGSPROVIDER)(LPCWSTR lpApplicationId, int *pnNumOfArgs);
typedef void (*PFNFAILURENOTIFICATION)(SingleInstanceManagerException ex);
typedef void (*PFNARGSNOTIFICATION)(LPCWSTR* pArgs, DWORD dwLength, BOOL bIsRemoteAdmin, LPVOID pContext);
