#pragma once

#include <windows.h>
#include "ArgumentsHandlerInvoker.h"

/// <summary>
/// A general-purpose <see cref="ArgumentsHandlerInvoker"/> which invokes argument handlers on the incoming thread.
/// </summary>
class SINGLEINSTANCE_API PassThroughInvoker : public ArgumentsHandlerInvoker
{
protected:
    /// <summary>
    /// Invokes the given handler on the incoming therad.
    /// </summary>
    /// <param name="pHandlerToInvoke">The handler to invoke.</param>
    /// <param name="pArgs">The command line arguments to deliver.</param>
	/// <param name="dwLength">The number of command line arguments.</param>
	/// <param name="pContext">A pointer to a possible context class.</param>
	virtual void Invoke(PFNARGSHANDLER pHandlerToInvoke, LPCWSTR *pArgs, DWORD dwLength, LPVOID pContext);
};