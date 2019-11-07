#include "stdafx.h"
#include "ArgumentsDeliveryStrategy.h"

void ArgumentsDeliveryStrategy::NotifyArgumentsReceived(LPCWSTR *pArgs, DWORD dwLength, BOOL bIsRemoteAdmin)
{
	PFNARGSNOTIFICATION pfnLocal = m_pfnArgsNotification; // Create local copy to avoid concurrency issues on cleanup
	if (pfnLocal != NULL)
		pfnLocal(pArgs, dwLength, bIsRemoteAdmin, m_pContext);
}

void ArgumentsDeliveryStrategy::InitializeFirstInstance(LPCWSTR lpApplicationId, PFNARGSNOTIFICATION pfnArgsNotification, LPVOID pContext)
{
	m_pfnArgsNotification = pfnArgsNotification;
	m_pContext = pContext;
	OnInitializeFirstInstance(lpApplicationId);
}

void ArgumentsDeliveryStrategy::DeliverArgumentsToFirstInstance(LPCWSTR lpApplicationId, LPWSTR *pArgs, DWORD dwLength)
{
	OnDeliverArgumentsToFirstInstance(lpApplicationId, pArgs, dwLength);
}

