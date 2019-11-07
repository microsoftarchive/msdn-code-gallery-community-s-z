#pragma once

#include <windows.h>
#include "SingleInstance.h"
#include "TypeDeclarations.h"

class SingleInstanceManager;

/// <summary>
/// Implement this abstract class to provide a custom arguments handler invoker.
/// </summary>
/// <remarks>
/// A default invoker is provided out-of-the-box, for invoking handlers on the incoming thread.
/// Implement this interface to provide custom handler invocation.
/// </remarks>
class SINGLEINSTANCE_API ArgumentsHandlerInvoker abstract
{
	friend SingleInstanceManager;

protected:
    /// <summary>
    /// The method called to invoke the handler.
    /// </summary>
    /// <param name="pHandlerToInvoke">The handler to invoke.</param>
    /// <param name="pArgs">The command line arguments to deliver.</param>
	/// <param name="dwLength">The number of command line arguments.</param>
	/// <param name="pContext">A pointer to a possible context class.</param>
	virtual void Invoke(PFNARGSHANDLER pHandlerToInvoke, LPCWSTR *pArgs, DWORD dwLength, LPVOID pContext) = 0;
};