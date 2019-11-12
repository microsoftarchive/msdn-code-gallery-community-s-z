#pragma once

#include <exception>
#include "SingleInstance.h"

class SingleInstanceManager;

/// <summary>
/// The exception class throw by the <see cref="SingleInstanceManager"/> when an exception occurs.
/// </summary>
class SINGLEINSTANCE_API SingleInstanceManagerException : public std::exception
{
public:
	/// <summary>
	/// Constructs the exception instance with an empty message.
	/// </summary>
	SingleInstanceManagerException();

	/// <summary>
	/// Constructs the exception instance with the given message.
	/// </summary>
	SingleInstanceManagerException(const char *const &message);

	/// <summary>
	/// Copy constructor.
	/// </summary>
	SingleInstanceManagerException(const SingleInstanceManagerException &right);
};
