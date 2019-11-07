#pragma once

#include <windows.h>
#include "ArgumentsDeliveryStrategy.h"

/// <summary>
/// An implementation of an <see cref="ArgumentsDeliveryStrategy"/> using names pipes as the communication mechanism.
/// </summary>
class NamedPipeStrategy : public ArgumentsDeliveryStrategy
{
public:
	NamedPipeStrategy();
	~NamedPipeStrategy();
protected:
    /// <summary>
    /// Initalize a listener for incoming command line arguments, as the first application instance, using a named pipe.
    /// </summary>
    /// <param name="lpApplicationId">The application ID which identifies the application as a single instance.</param>
	virtual void OnInitializeFirstInstance(LPCWSTR lpApplicationId);

    /// <summary>
    /// Delivers the command line arguments to the first application instance, via a named pipe to a remote application.
    /// </summary>
    /// <param name="lpApplicationId">The application ID which identifies the application as a single instance.</param>
    /// <param name="pArgs">The command line arguments to deliver.</param>
	/// <param name="dwLength">The number of command line arguments.</param>
	virtual void OnDeliverArgumentsToFirstInstance(LPCWSTR lpApplicationId, LPWSTR *pArgs, DWORD dwLength);

private:
	DWORD ReceiveThread();
	static unsigned int WINAPI RecieveThreadStatic(void *lpvHandlePipe);
	static HANDLE CreatePipe(LPCWSTR lpApplicationId, bool bCreateServerPipe);
	static BOOL GetSecurityAttrsMediumIL(LPSECURITY_ATTRIBUTES secAttrs);
	void InitOverlapped();
	void CloseOverlapped();

	HANDLE m_hPipe;
	HANDLE m_hReceiverThread;
	HANDLE m_hReceiverTerminationEvent;
	volatile BOOL   m_bRunLoop;
	OVERLAPPED m_ov;
};