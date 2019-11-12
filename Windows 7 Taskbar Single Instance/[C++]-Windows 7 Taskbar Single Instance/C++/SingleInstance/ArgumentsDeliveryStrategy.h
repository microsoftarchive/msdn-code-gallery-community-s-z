#pragma once

#include <windows.h>
#include "SingleInstance.h"
#include "TypeDeclarations.h"

class SingleInstanceManager;

/// <summary>
/// The base class for implementing a strategy to recieve and deliver command line arguments from/to other application instances.
/// </summary>
/// <remarks>
/// Inherit this class to implement your own command line arguments notification strategy. 
/// When this is the first application instance, the strategy is used to recieve notifications of command line arguments from new application instances.
/// When this is not the first application instance, the strategy is used to deliver the command line arguments to the first application instance.
/// </remarks>
class SINGLEINSTANCE_API ArgumentsDeliveryStrategy abstract
{
	friend SingleInstanceManager;

protected:
    /// <summary>
    /// Override this method to initalize a listener to incoming command line arguments, as the first application instance.
    /// </summary>
    /// <param name="lpApplicationId">The application ID which identifies the application as a single instance.</param>
	virtual void OnInitializeFirstInstance(LPCWSTR lpApplicationId) = 0;

    /// <summary>
    /// Override this method to deliver the command line arguments to the first application instance.
    /// </summary>
    /// <param name="lpApplicationId">The application ID which identifies the application as a single instance.</param>
    /// <param name="pArgs">The command line arguments to deliver.</param>
	/// <param name="dwLength">The number of command line arguments.</param>
    /// <remarks>
    /// If the delivery fails, an appropriate excption should be thrown.
    /// </remarks>
	virtual void OnDeliverArgumentsToFirstInstance(LPCWSTR lpApplicationId, LPWSTR *pArgs, DWORD dwLength) = 0;

    /// <summary>
    /// Derived classes should call this method to notify the application instance of incoming command line arguments.
    /// </summary>
    /// <param name="pArgs">The command line arguments recieved.</param>
	/// <param name="dwLength">The number of command line arguments.</param>
    /// <param name="bIsRemoteAdmin">true if the remote party has admin priviliges, false otherwise.</param>
	void NotifyArgumentsReceived(LPCWSTR *pArgs, DWORD dwLength, BOOL bIsRemoteAdmin);

private:
	void InitializeFirstInstance(LPCWSTR lpApplicationId, PFNARGSNOTIFICATION pfnArgsNotification, LPVOID pContext);
	void DeliverArgumentsToFirstInstance(LPCWSTR lpApplicationId, LPWSTR *pArgs, DWORD dwLength);

	PFNARGSNOTIFICATION m_pfnArgsNotification;
	LPVOID m_pContext;
};