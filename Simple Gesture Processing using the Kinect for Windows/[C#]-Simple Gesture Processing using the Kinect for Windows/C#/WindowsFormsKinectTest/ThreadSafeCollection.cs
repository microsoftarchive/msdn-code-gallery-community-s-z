//-----------------------------------------------------------------------
// <copyright file="ThreadSafeCollection.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// <summary>
// A list with locking semantics so it can be used cross-thread.
// </summary>
//-----------------------------------------------------------------------


namespace Microsoft.Kinect.Toolkit
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// IList implementation with locking on all operations.
    /// </summary>
    /// <typeparam name="T">Type of generic IList to implement.</typeparam>
    public sealed class ThreadSafeCollection<T> : IList<T>
    {
        /// <summary>
        /// Lock object to use for all operations.
        /// </summary>
        private readonly object lockObject;

        /// <summary>
        /// Wrapped collection object.
        /// </summary>
        private readonly List<T> list = new List<T>();
        
        /// <summary>
        /// Initializes a new instance of the ThreadSafeCollection class with a new lock.
        /// </summary>
        public ThreadSafeCollection() : this(new object())
        {
        }

        /// <summary>
        /// Initializes a new instance of the ThreadSafeCollection class with an existing new lock.
        /// </summary>
        /// <param name="existingLock">Existing lock to use for this collection.</param>
        public ThreadSafeCollection(object existingLock)
        {
            this.lockObject = existingLock;
        }

        /// <summary>
        /// Gets the number of elements actually contained in the ThreadSafeCollection&lt;T&gt;.
        /// </summary>
        public int Count
        {
            get
            {
                lock (this.lockObject)
                {
                    return list.Count;
                }
            }
        }

        /// <summary>
        /// Gets a value indicating whether the collection is read only.  Returns true.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                lock (this.lockObject)
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets or sets the element at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The element at the specified index.</returns>
        public T this[int index]
        {
            get
            {
                lock (this.lockObject)
                {
                    return list[index];
                }
            }

            set
            {
                lock (this.lockObject)
                {
                    list[index] = value;
                }
            }
        }

        /// <summary>
        /// Adds an object to the end of the ThreadSafeCollection&lt;T&gt;.
        /// </summary>
        /// <param name="item">
        /// The object to be added to the end of the ThreadSafeCollection&lt;T&gt;.
        /// The value can be null for reference types.
        /// </param>
        public void Add(T item)
        {
            lock (this.lockObject)
            {
                list.Add(item);
            }
        }

        /// <summary>
        /// Removes all elements from the ThreadSafeCollection&lt;T&gt;.
        /// </summary>
        public void Clear()
        {
            lock (this.lockObject)
            {
                list.Clear();
            }
        }

        /// <summary>
        /// Determines whether an element is in the ThreadSafeCollection&lt;T&gt;.
        /// </summary>
        /// <param name="item">
        /// The object to locate in the ThreadSafeCollection&lt;T&gt;. The value
        /// can be null for reference types.
        /// </param>
        /// <returns>
        /// true if item is found in the ThreadSafeCollection&lt;T&gt;; otherwise,
        /// false.
        /// </returns>
        public bool Contains(T item)
        {
            lock (this.lockObject)
            {
                return list.Contains(item);
            }
        }

        /// <summary>
        /// Copies the entire ThreadSafeCollection&lt;T&gt; to a compatible one-dimensional
        /// array, starting at the beginning of the target array.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional System.Array that is the destination of the elements
        /// copied from ThreadSafeCollection&lt;T&gt;. The System.Array must have
        /// zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">
        /// The zero-based index in array at which copying begins.
        /// </param>
        /// <exception cref="System.ArgumentNullException">Array is null.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">ArrayIndex is less than 0.</exception>
        /// <exception cref="System.ArgumentException">
        /// The number of elements in the source ThreadSafeCollection&lt;T&gt; is
        /// greater than the available space from arrayIndex to the end of the destination
        /// array.
        /// </exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (this.lockObject)
            {
                list.CopyTo(array, arrayIndex);
            }
        }

        /// <summary>
        /// Copies the entire ThreadSafeCollection&lt;Tgt; to a compatible one-dimensional
        /// array, starting at the beginning of the target array.
        /// </summary>
        /// <param name="array">
        /// The one-dimensional System.Array that is the destination of the elements
        /// copied from System.Collections.Generic.List&lt;Tgt;. The System.Array must have
        /// zero-based indexing.
        /// </param>
        /// <exception cref="System.ArgumentNullException">Array is null.</exception>
        /// <exception cref="System.ArgumentException">
        /// The number of elements in the source ThreadSafeCollection&lt;Tgt; is
        /// greater than the number of elements that the destination array can contain.
        /// </exception>
        public void CopyTo(T[] array)
        {
            lock (this.lockObject)
            {
                list.CopyTo(array);
            }
        }

        /// <summary>
        /// Adds the elements of the specified collection to the end of the ThreadSafeCollection&lt;T&gt;.
        /// </summary>
        /// <param name="collection">
        /// The collection whose elements should be added to the end of the ThreadSafeCollection&lt;T&gt;.
        /// The collection itself cannot be null, but it can contain elements that are
        /// null, if type T is a reference type.
        /// </param>
        /// <exception cref="System.ArgumentNullException">Collection is null.</exception>
        public void AddRange(IEnumerable<T> collection)
        {
            lock (this.lockObject)
            {
                list.AddRange(collection);
            }
        }

        /// <summary>
        /// Searches for the specified object and returns the zero-based index of the
        /// first occurrence within the entire ThreadSafeCollection&lt;T&gt;.
        /// </summary>
        /// <param name="item">
        /// The object to locate in the ThreadSafeCollection&lt;T&gt;. The value
        /// can be null for reference types.
        /// </param>
        /// <returns>
        /// The zero-based index of the first occurrence of item within the entire ThreadSafeCollection&lt;T&gt;,
        /// if found; otherwise, –1.
        /// </returns>
        public int IndexOf(T item)
        {
            lock (this.lockObject)
            {
                return list.IndexOf(item);
            }
        }

        /// <summary>
        /// Inserts an element into the ThreadSafeCollection&lt;T&gt; at the specified
        /// index.
        /// </summary>
        /// <param name="index">
        /// The zero-based index at which item should be inserted.
        /// </param>
        /// <param name="item">
        /// The object to insert. The value can be null for reference types.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">Index is less than 0.-or-index is greater than ThreadSafeCollection&lt;T&gt;.Count.</exception>
        public void Insert(int index, T item)
        {
            lock (this.lockObject)
            {
                list.Insert(index, item);
            }
        }

        /// <summary>
        /// Removes the element at the specified index of the ThreadSafeCollection&lt;T&gt;.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Index is less than 0.-or-index is equal to or greater than ThreadSafeCollection&lt;T&gt;.Count.</exception>
        public void RemoveAt(int index)
        {
            lock (this.lockObject)
            {
                list.RemoveAt(index);
            }
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the ThreadSafeCollection&lt;T&gt;.
        /// </summary>
        /// <param name="item">
        /// The object to remove from the ThreadSafeCollection&lt;T&gt;. The value
        /// can be null for reference types.
        /// </param>
        /// <returns>
        /// true if item is successfully removed; otherwise, false. This method also
        /// returns false if item was not found in the ThreadSafeCollection&lt;T&gt;.
        /// </returns>
        public bool Remove(T item)
        {
            lock (this.lockObject)
            {
                return list.Remove(item);
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the ThreadSafeCollection&lt;T&gt;.
        /// </summary>
        /// <remarks>This enumerator is a SNAPSHOT of the collection.  Keep this in mind when using this enumerator.</remarks>
        /// <returns>A ThreadSafeCollection&lt;T&gt;.Enumerator for the ThreadSafeCollection&lt;T&gt;.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            lock (this.lockObject)
            {
                return NewEnumerator();
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the ThreadSafeCollection&lt;T&gt;.
        /// </summary>
        /// <remarks>This enumerator is a SNAPSHOT of the collection.  Keep this in mind when using this enumerator.</remarks>
        /// <returns>A ThreadSafeCollection&lt;T&gt;.Enumerator for the ThreadSafeCollection&lt;T&gt;.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            lock (this.lockObject)
            {
                return NewEnumerator();
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the ThreadSafeCollection&lt;T&gt;.
        /// </summary>
        /// <remarks>This support function exists to satisfy code quality warning CA2000.  Otherwise, it would be in-line.</remarks>
        /// <returns>A ThreadSafeCollection&lt;T&gt;.Enumerator for the ThreadSafeCollection&lt;T&gt;.</returns>
        private IEnumerator<T> NewEnumerator()
        {
            return new ThreadSafeEnumerator(this);
        }

        /// <summary>
        /// Provides a SNAPSHOT enumerator of the collection.  Keep this in mind when using this enumerator.
        /// </summary>
        private class ThreadSafeEnumerator : IEnumerator<T>
        {
            /// <summary>
            /// Snapshot to enumerate.
            /// </summary>
            private readonly ThreadSafeCollection<T> collection;

            /// <summary>
            /// Internal enumerator of the snapshot.
            /// </summary>
            private readonly IEnumerator<T> enumerator;

            /// <summary>
            /// Initializes a new instance of the ThreadSafeEnumerator class, creating a snapshot of the given collection.
            /// </summary>
            /// <param name="collection">List to snapshot.</param>
            public ThreadSafeEnumerator(ThreadSafeCollection<T> collection)
            {
                lock (collection.lockObject)
                {
                    // Make snapshot of passed in collection.
                    this.collection = new ThreadSafeCollection<T>();
                    this.collection.AddRange(collection);

                    // Wrapped enumerator.
                    enumerator = this.collection.list.GetEnumerator();
                }
            }

            /// <summary>
            /// Gets the element in the collection at the current position of the enumerator.
            /// </summary>
            /// <returns>The element in the collection at the current position of the enumerator.</returns>
            public T Current
            {
                get
                {
                    lock (this.collection.lockObject)
                    {
                        return enumerator.Current;
                    }
                }
            }

            /// <summary>
            /// Gets the element in the collection at the current position of the enumerator.
            /// </summary>
            /// <returns>The element in the collection at the current position of the enumerator.</returns>
            object IEnumerator.Current
            {
                get
                {
                    lock (this.collection.lockObject)
                    {
                        return enumerator.Current;
                    }
                }
            }

            /// <summary>
            /// Disposes the underlying enumerator.  Does not set collection or enumerator to null so calls will still
            /// proxy to the disposed instance (and throw the proper exception).
            /// </summary>
            public void Dispose()
            {
                lock (this.collection.lockObject)
                {
                    enumerator.Dispose();
                }
            }

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// true if the enumerator was successfully advanced to the next element; false
            /// if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
            public bool MoveNext()
            {
                lock (this.collection.lockObject)
                {
                    return enumerator.MoveNext();
                }
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element
            /// in the collection.
            /// </summary>
            /// <exception cref="System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
            public void Reset()
            {
                lock (this.collection.lockObject)
                {
                    enumerator.Reset();
                }
            }
        }
    }
}
