#pragma once

#include <windows.h>
#include "SingleInstance.h"
#include "DeliveryStrategyFactory.h"

class NamedPipeStrategy;

/// <summary>
/// A factory class for creating an <see cref="ArgumentsDeliveryStrategy"/> of type <see cref="NamedPipeStrategy"/>.
/// </summary>
class SINGLEINSTANCE_API NamedPipeStrategyFactory : public DeliveryStrategyFactory
{
protected:
    /// <summary>
    /// Constructs and returnes a new instance of <see cref="NamedPipeStrategy"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="NamedPipeStrategy"/>.</returns>
	virtual ArgumentsDeliveryStrategy *CreateStrategy() const;
};