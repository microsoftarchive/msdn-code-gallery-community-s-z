#pragma once

#include <windows.h>
#include "TypeDeclarations.h"
#include "SingleInstanceManagerSetup.h"
#include "ArgumentsDeliveryStrategy.h"

/// <summary>
/// The main class used for setting up a single instance application.
/// </summary>
/// <remarks>
/// Use the <see cref="Initialize"/> method to create and initialize a single instance manager.
/// Note that normally only one instance of this class should be created.
/// </remarks>
class SINGLEINSTANCE_API SingleInstanceManager sealed
{
public:
    /// <summary>
    /// Constructs and initializes a new instance of the single instance manager.
    /// </summary>
    /// <param name="setup">Setup information for the single instance manager.</param>
    /// <returns>An initialized single instance manager.</returns>
    /// <remarks>
    /// Use this method to initialize a single instance manager with the given setup information.
    /// Note that normally only one call to this method should be performed, at the beggining of the application execution.
	/// Also note that memory allocated with this method should be realeased with the <see cref="delete"/> operator.
    /// </remarks>
	static const SingleInstanceManager *Initialize(const SingleInstanceManagerSetup &setup);
	~SingleInstanceManager();

private:
	SingleInstanceManager(LPCWSTR lpApplicationId, PFNARGSHANDLER pfnArgumentsHandler, LPVOID pContext, ArgumentsDeliveryStrategy *pStrategy, 
		PFNARGSPROVIDER pfnArgumentsProvider, ArgumentsHandlerInvoker *pHandlerInvoker, InstanceNotificationOption inoNotification,
		PFNFAILURENOTIFICATION pfnDeliveryFailureNotification);	

	static const DeliveryStrategyFactory *GetDefaultFactory();
	static void GenerateUserLocalId(LPCWSTR lpApplicationId, LPWSTR lpBuffer, DWORD dwLength);
	static LPWSTR *DefaultArgumentsProvider(LPCWSTR lpApplicationId, int *pnNumOfArgs);

    /// <summary>
    /// Used to check if this is the first application instance, and act accordingly.
    /// </summary>
    /// <returns>TRUE if this is the first application instance, FALSE otherwise.</returns>
    /// <remarks>
    /// If this is the first application instance, the argument delivery strategy is initialized to listen for incoming argument notifications.
    /// Otherwise, the argument delivery strategy is used to notify the already running application instance.
    /// </remarks>
	BOOL TryEnsureFirstInstance();

    /// <summary>
    /// Checks if an application instance was already created, and marks this as the first instance if it is not.
    /// </summary>
    /// <returns>TRUE if this is the first application instance, FALSE otherwise.</returns>
	BOOL IsFirstApplicationInstance();

    /// <summary>
    /// Notifies the registered handler of the arguments recieved.
    /// </summary>
    /// <param name="pArguments">The command line arguments recieved.</param>
    /// <param name="dwLength">The number of command line arguments.</param>
    /// <param name="bRemoteIsAdmin">Indicates whether the remote party is an administrator.</param>
    /// <remarks>
    /// Note that notification is performed according to the <see cref="InstanceNotificationOption"/> given in the manager setup. 
    /// In addition, note that the registered handler is invoked using the handler invoker supplied upon <see cref="Initialize">initializtion</see>.
    /// </remarks>
	void NotifyArgumentsReceived(LPCWSTR *pArguments, DWORD dwLength, BOOL bRemoteIsAdmin);
	static void NotifyArgumentsReceivedStatic(LPCWSTR *pArguments, DWORD dwLength, BOOL remoteIsAdmin, LPVOID pContext);

	LPCWSTR m_lpApplicationId;
	PFNARGSHANDLER m_pfnArgumentsHandler;
	ArgumentsDeliveryStrategy *m_pStrategy;
	PFNARGSPROVIDER m_pfnArgumentsProvider;
	ArgumentsHandlerInvoker *m_pHandlerInvoker;
	InstanceNotificationOption m_inoNotification;
	PFNFAILURENOTIFICATION m_pfnDeliveryFailureNotification;

	LPVOID m_pContext;
	HANDLE m_hMutex;
};