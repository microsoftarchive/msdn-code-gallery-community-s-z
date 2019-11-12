#pragma once

#include <windows.h>
#include "SingleInstance.h"
#include "ArgumentsDeliveryStrategy.h"

class SingleInstanceManager;

/// <summary>
/// The base class for a command line arguments delivery strategy factory.
/// </summary>
/// <remarks>
/// Derive this class to enable the <see cref="SingleInstanceManager"/> to use a custom delivery strategy.
/// </remarks>
class SINGLEINSTANCE_API DeliveryStrategyFactory abstract
{
	friend SingleInstanceManager;

protected:
    /// <summary>
    /// Override this method to return a custom <see cref="ArgumentsDeliveryStrategy"/>.
    /// </summary>
    /// <returns>A custom <see cref="ArgumentsDeliveryStrategy"/>.</returns>
	virtual ArgumentsDeliveryStrategy *CreateStrategy() const = 0;
};