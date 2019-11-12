// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

namespace Microsoft.Windows.Controls.DataVisualization
{
    /// <summary>
    /// A structure that groups two values.
    /// </summary>
    /// <typeparam name="T0">The type of the first value.</typeparam>
    /// <typeparam name="T1">The type of the second value.</typeparam>
    internal struct Tuple<T0, T1>
    {
        /// <summary>
        /// Gets the first value.
        /// </summary>
        public T0 First { get; private set; }

        /// <summary>
        /// Gets the second value.
        /// </summary>
        public T1 Second { get; private set; }

        /// <summary>
        /// Initializes a new instance of the Tuple structure.
        /// </summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        public Tuple(T0 first, T1 second) : this()
        {
            First = first;
            Second = second;
        }
    }
}