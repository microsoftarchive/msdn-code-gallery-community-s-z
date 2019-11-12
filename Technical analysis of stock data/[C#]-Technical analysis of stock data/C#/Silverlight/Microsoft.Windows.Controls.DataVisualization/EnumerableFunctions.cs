// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Windows.Controls.DataVisualization
{
    /// <summary>
    /// This class contains general purpose functions to manipulate the generic
    /// IEnumerable type.
    /// </summary>
    internal static class EnumerableFunctions
    {
        /// <summary>
        /// Returns whether a sequence is empty.
        /// </summary>
        /// <typeparam name="T">The type of the sequence.</typeparam>
        /// <param name="that">The sequence.</param>
        /// <returns>Whether the sequence is empty or not.</returns>
        public static bool IsEmpty<T>(this IEnumerable<T> that)
        {
            IEnumerator<T> enumerator = that.GetEnumerator();
            return !enumerator.MoveNext();
        }

        /////// <summary>
        /////// Performs a projection with the index of the item in the sequence.
        /////// </summary>
        /////// <typeparam name="T">The type of the sequence.</typeparam>
        /////// <typeparam name="R">The type of the returned sequence.</typeparam>
        /////// <param name="that">The sequence to apply the projection to.</param>
        /////// <param name="func">The function to apply to each item.</param>
        /////// <returns>A sequence of the returned values.</returns>
        ////public static IEnumerable<R> SelectWithIndex<T, R>(this IEnumerable<T> that, Func<T, int, R> func)
        ////{
        ////    int counter = 0;

        ////    foreach (T item in that)
        ////    {
        ////        yield return func(item, counter);
        ////        counter++;
        ////    }
        ////}

        /// <summary>
        /// Accepts two sequences and applies a function to the corresponding 
        /// values in the two sequences.
        /// </summary>
        /// <typeparam name="T0">The type of the first sequence.</typeparam>
        /// <typeparam name="T1">The type of the second sequence.</typeparam>
        /// <typeparam name="R">The return type of the function.</typeparam>
        /// <param name="enumerable0">The first sequence.</param>
        /// <param name="enumerable1">The second sequence.</param>
        /// <param name="func">The function to apply to the corresponding values
        /// from the two sequences.</param>
        /// <returns>A sequence of transformed values from both sequences.</returns>
        public static IEnumerable<R> Zip<T0, T1, R>(IEnumerable<T0> enumerable0, IEnumerable<T1> enumerable1, Func<T0, T1, R> func)
        {
            IEnumerator<T0> enumerator0 = enumerable0.GetEnumerator();
            IEnumerator<T1> enumerator1 = enumerable1.GetEnumerator();
            while (enumerator0.MoveNext() && enumerator1.MoveNext())
            {
                yield return func(enumerator0.Current, enumerator1.Current);
            }
        }

        /// <summary>
        /// Creates a sequence of values by accepting an initial value, an 
        /// iteration function, and apply the iteration function recursively.
        /// </summary>
        /// <typeparam name="T">The type of the sequence.</typeparam>
        /// <param name="value">The initial value.</param>
        /// <param name="nextFunction">The function to apply to the value.
        /// </param>
        /// <returns>A sequence of the iterated values.</returns>
        public static IEnumerable<T> Iterate<T>(T value, Func<T, T> nextFunction)
        {
            yield return value;
            while (true)
            {
                value = nextFunction(value);
                yield return value;
            }
        }

        /// <summary>
        /// Returns the index of an item in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the sequence.</typeparam>
        /// <param name="that">The sequence.</param>
        /// <param name="value">The item to search for.</param>
        /// <returns>The index of the item or -1 if not found.</returns>
        public static int IndexOf<T>(this IEnumerable<T> that, T value)
        {
            int index = 0;
            foreach (T item in that)
            {
                if (object.ReferenceEquals(value, item) || value.Equals(item))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }

        /// <summary>
        /// Returns the index of an item in a sequence.
        /// </summary>
        /// <typeparam name="T">The type of the sequence.</typeparam>
        /// <param name="that">The sequence.</param>
        /// <param name="func">The item to search for.</param>
        /// <returns>The index of the item or -1 if not found.</returns>
        public static int? IndexOf<T>(this IEnumerable<T> that, Func<T, bool> func)
        {
            int index = 0;
            foreach (T item in that)
            {
                if (func(item))
                {
                    return index;
                }
                index++;
            }
            return new int?();
        }

        /// <summary>
        /// Executes an action for each item and a sequence, passing in the 
        /// index of that item to the action procedure.
        /// </summary>
        /// <typeparam name="T">The type of the sequence.</typeparam>
        /// <param name="that">The sequence.</param>
        /// <param name="action">A function that accepts a sequence item and its
        /// index in the sequence.</param>
        public static void ForEachWithIndex<T>(this IEnumerable<T> that, Action<T, int> action)
        {
            int index = 0;
            foreach (T item in that)
            {
                action(item, index);
                index++;
            }
        }

        /////// <summary>
        /////// Returns the maximum value or null if sequence is empty.
        /////// </summary>
        /////// <param name="that">The sequence to retrieve the maximum value from.
        /////// </param>
        /////// <returns>The maximum value or null.</returns>
        ////public static T MaxOrNull<T>(this IEnumerable<T> that)
        ////    where T : class, IComparable
        ////{
        ////    if (!that.Any())
        ////    {
        ////        return null;
        ////    }
        ////    return that.Max();
        ////}

        /////// <summary>
        /////// Returns the minimum value or null if sequence is empty.
        /////// </summary>
        /////// <param name="that">The sequence to retrieve the minimum value from.
        /////// </param>
        /////// <returns>The minimum value or null.</returns>
        ////public static T MinOrNull<T>(this IEnumerable<T> that)
        ////    where T : class, IComparable
        ////{
        ////    if (!that.Any())
        ////    {
        ////        return null;
        ////    }
        ////    return that.Min();
        ////}

        /// <summary>
        /// Returns the maximum value or null if sequence is empty.
        /// </summary>
        /// <typeparam name="T">The type of the sequence.</typeparam>
        /// <param name="that">The sequence to retrieve the maximum value from.
        /// </param>
        /// <returns>The maximum value or null.</returns>
        public static T? MaxOrNullable<T>(this IEnumerable<T> that)
            where T : struct, IComparable
        {
            if (!that.Any())
            {
                return null;
            }
            return that.Max();
        }

        /// <summary>
        /// Returns the minimum value or null if sequence is empty.
        /// </summary>
        /// <typeparam name="T">The type of the sequence.</typeparam>
        /// <param name="that">The sequence to retrieve the minimum value from.
        /// </param>
        /// <returns>The minimum value or null.</returns>
        public static T? MinOrNullable<T>(this IEnumerable<T> that)
            where T : struct, IComparable
        {
            if (!that.Any())
            {
                return null;
            }
            return that.Min();
        }

        /////// <summary>
        /////// Accepts two sequences and returns a sequence of pairs containing one 
        /////// item from each sequence at a corresponding index.
        /////// </summary>
        /////// <typeparam name="T">The type of the sequences.</typeparam>
        /////// <param name="sequence0">The first sequence.</param>
        /////// <param name="sequence1">The second sequence.</param>
        /////// <returns>A sequence of pairs.</returns>
        ////public static IEnumerable<Pair<T>> ZipPair<T>(IEnumerable<T> sequence0, IEnumerable<T> sequence1)
        ////{
        ////    IEnumerator<T> enumerable0 = sequence0.GetEnumerator();
        ////    IEnumerator<T> enumerable1 = sequence1.GetEnumerator();
        ////    while (enumerable0.MoveNext() && enumerable1.MoveNext())
        ////    {
        ////        yield return new Pair<T>(enumerable0.Current, enumerable1.Current);
        ////    }
        ////}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <typeparam name="K"></typeparam>
        ///// <typeparam name="R"></typeparam>
        ///// <param name="that"></param>
        ///// <param name="keySelector"></param>
        ///// <param name="itemSelector"></param>
        ///// <returns></returns>
        ////public static Dictionary<KeyType, ItemType> ToTransformedDictionary<InputType, KeyType, ItemType>(this IEnumerable<InputType> that, Func<InputType, KeyType> keySelector, Func<InputType, ItemType> itemSelector)
        ////{
        ////    Dictionary<KeyType, ItemType> dictionary = new Dictionary<KeyType, ItemType>();
        ////    foreach (InputType item in that)
        ////    {
        ////        dictionary[keySelector(item)] = itemSelector(item);
        ////    }
        ////    return dictionary;
        ////}
    }
}