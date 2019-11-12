#include "StdAfx.h"
#include "SingleInstanceManagerException.h"

SingleInstanceManagerException::SingleInstanceManagerException() : std::exception()
{
}

SingleInstanceManagerException::SingleInstanceManagerException(const char *const &message) : std::exception(message)
{
}

SingleInstanceManagerException::SingleInstanceManagerException(const SingleInstanceManagerException &right) : std::exception(right)
{
}
