#include "stdafx.h"
#include "NamedPipeStrategyFactory.h"
#include "NamedPipeStrategy.h"

ArgumentsDeliveryStrategy *NamedPipeStrategyFactory::CreateStrategy() const
{
	return new NamedPipeStrategy();
}
