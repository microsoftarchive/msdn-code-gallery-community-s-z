// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved
//
// Adapted from http://code.msdn.microsoft.com/windowsapps/Windows-8-Asynchronous-08009a0d/

#pragma once

#include <ppltasks.h>

namespace Concurrency
{
	namespace extras
	{
		namespace details
		{
			static void iterative_task_impl(concurrency::task_completion_event<void> finished, std::function<concurrency::task<bool>()> body, concurrency::cancellation_token ct)
			{
				body().then([=](concurrency::task<bool> previous) {
					try {
						if (previous.get())
							iterative_task_impl(finished, body, ct);
						else
							finished.set();
					}
					catch (...) {
						finished.set_exception(std::current_exception());
					}
				}, ct);
			}
		} // namespace details

		/// <summary>
		///     Creates a task iteratively execute user Functor. During the process, each new iteration will be the continuation of the
		///     last iteration's returning task, and the process will keep going on until the Boolean value from returning task becomes False.
		/// </summary>
		/// <param name="body">
		///     The user Functor used as loop body. It is required to return a task with type bool, which used as predictor that decides
		///     whether the loop needs to be continued.
		/// </param>
		/// <param name="ct">
		///     The cancellation token linked to the iterative task.
		/// </param>
		/// <returns>
		///     The task that will perform the asynchronous iterative execution.
		/// </returns>
		/// <remarks>
		///     This function dynamically creates a long chain of continuations by iteratively concating tasks created by user Functor <paramref name="body"/>,
		///     The iteration will not stop until the result of the returning task from user Functor <paramref name="body"/> is <c> False </c>.
		/// </remarks>
		/// <seealso cref="Task Parallelism (Concurrency Runtime)"/>
		/**/
		inline task<void> create_iterative_task(std::function<concurrency::task<bool>()> body, cancellation_token ct = cancellation_token::none())
		{
			concurrency::task_completion_event<void> finished;
			create_task([=] {
				try {
					details::iterative_task_impl(finished, body, ct);
				}
				catch (...) {
					finished.set_exception(std::current_exception());
				}
			}, ct);
			return create_task(finished, ct);
		}

		// Returns a task that returns a value immediately.
		template <typename T>
		inline task<T> create_value_task(T returnValue)
		{
			task_completion_event<T> tce;
			tce.set(returnValue);
			return create_task(tce);
		}

	}
}