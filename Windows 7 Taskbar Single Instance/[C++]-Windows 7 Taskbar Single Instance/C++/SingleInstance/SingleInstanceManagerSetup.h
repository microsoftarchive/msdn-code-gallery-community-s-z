#pragma once

#include <windows.h>
#include "SingleInstance.h"
#include "TypeDeclarations.h"
#include "DeliveryStrategyFactory.h"
#include "ArgumentsHandlerInvoker.h"

/// <summary>
/// Represents the action to perform when trying to initalize a <see cref="SingleInstanceManager"/>
/// which is not the first application instance.
/// </summary>
enum TerminationOption
{
    /// <summary>
	/// Exit the application using <see cref="ExitProcess"/>.
    /// </summary>
	TerminationOption_Exit,
    /// <summary>
    /// Throw an exception.
    /// </summary>
	TerminationOption_Throw
};

/// <summary>
/// Used to set the behavior of the <see cref="SingleInstanceManager"/> when the first application instance is run as an admin.
/// </summary>
/// <remarks>
/// If the first application instance is not run as an administrator, then setting this setting has no effect.
/// </remarks>
enum InstanceNotificationOption
{
    /// <summary>
    /// Always allow the first application instance to be notified of incoming arguments, regardless of whether these
    /// arguments originate from an admin or non-admin instance.
    /// </summary>
	InstanceNotificationOption_NotifyAnyway,
    /// <summary>
    /// Only allows the first (admin) application instance to be notified of incoming arguments, if these arguments
    /// originate from an admin instance.
    /// </summary>
	InstanceNotificationOption_NotifyOnlyIfAdmin
};

/// <summary>
/// Used to pass initialization data to an initialized instance of the <see cref="SingleInstanceManager"/>.
/// </summary>
class SINGLEINSTANCE_API SingleInstanceManagerSetup sealed
{
public:
    /// <summary>
    /// Constructs a new instance of the <see cref="SingleInstanceManagerSetup"/> class.
    /// </summary>
	/// <param name="lpApplicationId">The application ID which is used to identify the application as a single instance.</param>
	/// <param name="pfnArgumentsHandler">The handler invoked when command line arguments are recieved from a remote instance.</param>
	/// <param name="pArgsHandlerContext">A context class to be passed to the arguments handler.</param>
	/// <param name="toTermination">The action to perform when trying to initalize a <see cref="SingleInstanceManager"/>
    /// which is not the first application instance.</param>
	/// <param name="nExitCode">The exit code to be used if this is not the first application instance, and <see cref="TerminationOption_Exit"/>
    /// is specified for <see cref="TerminationOption"/>.</param>
	/// <param name="pfnArgumentsProvider">A custom provider for the current process' command line arguments. Memory allocated by the provider shall be released with <see cref="LocalFree"/>.</param>
	/// <param name="pStrategyFactory">A custom provider for the command line arguments delivery strategy.</param>
	/// <param name="pHandlerInvoker">A custom arguments handler invoker. This parameter should not be released as long as the manager using it exists.</param>
	/// <param name="anoNotification">Used to set the behavior of the <see cref="SingleInstanceManager"/> when the first application instance is run as an admin.</param>
	/// <param name="pfnDeliveryFailureNotification">Specify a handler to be called when delivery of command line arguments to the first instance has failed for some reason.</param>
	SingleInstanceManagerSetup(LPCWSTR lpApplicationId, PFNARGSHANDLER pfnArgumentsHandler = NULL, LPVOID pArgsHandlerContext = NULL,
		TerminationOption toTermination = TerminationOption_Exit, UINT nExitCode = 0, PFNARGSPROVIDER pfnArgumentsProvider = NULL, 
		const DeliveryStrategyFactory *pStrategyFactory = NULL, ArgumentsHandlerInvoker *pHandlerInvoker = NULL, 
		InstanceNotificationOption inoNotification = InstanceNotificationOption_NotifyAnyway, PFNFAILURENOTIFICATION pfnDeliveryFailureNotification = NULL);

	LPCWSTR GetApplicationId() const;
	void SetApplicationId(LPCWSTR lpApplicationId);

	PFNARGSHANDLER GetArgsHandler() const;
	void SetArgsHandler(PFNARGSHANDLER pfnArgumentsHandler);

	LPVOID SingleInstanceManagerSetup::GetArgsHandlerContext() const;
	void SingleInstanceManagerSetup::SetArgsHandlerContext(LPVOID pContext);
	
	TerminationOption GetTerminationOption() const;
	void SetTerminationOption(TerminationOption toTermination);

	UINT GetExitCode() const;
	void SetExitCode(UINT nExitCode);

	PFNARGSPROVIDER GetArgsProvider() const;
	void SetArgsProvider(PFNARGSPROVIDER pfnArgumentsProvider);

	const DeliveryStrategyFactory *GetStrategyFactory() const;
	void SetStrategyFactory(const DeliveryStrategyFactory *pStrategyFactory);

	ArgumentsHandlerInvoker *GetHandlerInvoker() const;
	void SetHandlerInvoker(ArgumentsHandlerInvoker *pHandlerInvoker);

	InstanceNotificationOption GetInstanceNotificationOption() const;
	void SetInstanceNotificationOption(InstanceNotificationOption inoNotification);

	PFNFAILURENOTIFICATION GetDeliveryFailureNotification() const;
	void SetDeliveryFailureNotification(PFNFAILURENOTIFICATION pfnDeliveryFailureNotification);

private:
	LPCWSTR m_lpApplicationId;
	PFNARGSHANDLER m_pfnArgumentsHandler;
	LPVOID m_pArgsHandlerContext;
	TerminationOption m_toTermination;
	DWORD m_nExitCode;
	PFNARGSPROVIDER m_pfnArgumentsProvider;
	const DeliveryStrategyFactory *m_pStrategyFactory;
	ArgumentsHandlerInvoker *m_pHandlerInvoker;
	InstanceNotificationOption m_inoNotification;
	PFNFAILURENOTIFICATION m_pfnDeliveryFailureNotification;
};