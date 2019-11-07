#include "stdafx.h"
#include "SingleInstanceManagerSetup.h"
#include "SingleInstanceManagerException.h"

SingleInstanceManagerSetup::SingleInstanceManagerSetup(LPCWSTR lpApplicationId, PFNARGSHANDLER pfnArgumentsHandler, LPVOID pArgsHandlerContext, TerminationOption toTermination, 
													   UINT nExitCode, PFNARGSPROVIDER pfnArgumentsProvider, const DeliveryStrategyFactory *pStrategyFactory, 
													   ArgumentsHandlerInvoker *pHandlerInvoker, InstanceNotificationOption inoNotification, 
													   PFNFAILURENOTIFICATION pfnDeliveryFailureNotification)
{
	SetApplicationId(lpApplicationId);
	SetArgsHandler(pfnArgumentsHandler);
	SetArgsHandlerContext(pArgsHandlerContext);
	SetTerminationOption(toTermination);
	SetExitCode(nExitCode);
	SetArgsProvider(pfnArgumentsProvider);
	SetStrategyFactory(pStrategyFactory);
	SetHandlerInvoker(pHandlerInvoker);
	SetInstanceNotificationOption(inoNotification);
	SetDeliveryFailureNotification(pfnDeliveryFailureNotification);
}

LPCWSTR SingleInstanceManagerSetup::GetApplicationId() const
{
	return m_lpApplicationId;
}

void SingleInstanceManagerSetup::SetApplicationId(LPCWSTR lpApplicationId)
{
	if (lpApplicationId == NULL)
		throw SingleInstanceManagerException("NULL is not a valid value for application ID");
	m_lpApplicationId = lpApplicationId;
}

PFNARGSHANDLER SingleInstanceManagerSetup::GetArgsHandler() const
{
	return m_pfnArgumentsHandler;
}

void SingleInstanceManagerSetup::SetArgsHandler(PFNARGSHANDLER pfnArgumentsHandler)
{
	m_pfnArgumentsHandler = pfnArgumentsHandler;
}

LPVOID SingleInstanceManagerSetup::GetArgsHandlerContext() const
{
	return m_pArgsHandlerContext;
}

void SingleInstanceManagerSetup::SetArgsHandlerContext(LPVOID pContext)
{
	m_pArgsHandlerContext = pContext;
}

TerminationOption SingleInstanceManagerSetup::GetTerminationOption() const
{
	return m_toTermination;
}

void SingleInstanceManagerSetup::SetTerminationOption(TerminationOption toTermination)
{
	m_toTermination = toTermination;
}

UINT SingleInstanceManagerSetup::GetExitCode() const
{
	return m_nExitCode;
}

void SingleInstanceManagerSetup::SetExitCode(UINT nExitCode)
{
	m_nExitCode = nExitCode;
}

PFNARGSPROVIDER SingleInstanceManagerSetup::GetArgsProvider() const
{
	return m_pfnArgumentsProvider;
}

void SingleInstanceManagerSetup::SetArgsProvider(PFNARGSPROVIDER pfnArgumentsProvider)
{
	m_pfnArgumentsProvider = pfnArgumentsProvider;
}

const DeliveryStrategyFactory *SingleInstanceManagerSetup::GetStrategyFactory() const
{
	return m_pStrategyFactory;
}

void SingleInstanceManagerSetup::SetStrategyFactory(const DeliveryStrategyFactory *pStrategyFactory)
{
	m_pStrategyFactory = pStrategyFactory;
}

ArgumentsHandlerInvoker *SingleInstanceManagerSetup::GetHandlerInvoker() const
{
	return m_pHandlerInvoker;
}

void SingleInstanceManagerSetup::SetHandlerInvoker(ArgumentsHandlerInvoker *pHandlerInvoker)
{
	m_pHandlerInvoker = pHandlerInvoker;
}

InstanceNotificationOption SingleInstanceManagerSetup::GetInstanceNotificationOption() const
{
	return m_inoNotification;
}

void SingleInstanceManagerSetup::SetInstanceNotificationOption(InstanceNotificationOption inoNotification)
{
	m_inoNotification = inoNotification;
}

PFNFAILURENOTIFICATION SingleInstanceManagerSetup::GetDeliveryFailureNotification() const
{
	return m_pfnDeliveryFailureNotification;
}

void SingleInstanceManagerSetup::SetDeliveryFailureNotification(PFNFAILURENOTIFICATION pfnDeliveryFailureNotification)
{
	m_pfnDeliveryFailureNotification = pfnDeliveryFailureNotification;
}
