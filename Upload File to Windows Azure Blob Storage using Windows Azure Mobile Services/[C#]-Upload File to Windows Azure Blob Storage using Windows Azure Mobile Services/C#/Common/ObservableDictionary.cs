// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

namespace MobileServices.Samples.MyPictures.Common
{
    using System.Collections.Generic;
    using System.Linq;
    using Windows.Foundation.Collections;

    /// <summary>
    /// Implementation of IObservableMap that supports reentrancy for use as a default view
    /// model.
    /// </summary>
    public class ObservableDictionary : IObservableMap<string, object>
    {
        private Dictionary<string, object> dictionary = new Dictionary<string, object>();

        public event MapChangedEventHandler<string, object> MapChanged;

        public ICollection<string> Keys
        {
            get { return this.dictionary.Keys; }
        }

        public ICollection<object> Values
        {
            get { return this.dictionary.Values; }
        }

        public int Count
        {
            get { return this.dictionary.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public object this[string key]
        {
            get
            {
                return this.dictionary[key];
            }

            set
            {
                this.dictionary[key] = value;
                this.InvokeMapChanged(CollectionChange.ItemChanged, key);
            }
        }

        public void Add(string key, object value)
        {
            this.dictionary.Add(key, value);
            this.InvokeMapChanged(CollectionChange.ItemInserted, key);
        }

        public void Add(KeyValuePair<string, object> item)
        {
            this.Add(item.Key, item.Value);
        }

        public bool Remove(string key)
        {
            if (this.dictionary.Remove(key))
            {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, key);
                return true;
            }

            return false;
        }

        public bool Remove(KeyValuePair<string, object> item)
        {
            object currentValue;
            if (this.dictionary.TryGetValue(item.Key, out currentValue) &&
                object.Equals(item.Value, currentValue) && this.dictionary.Remove(item.Key))
            {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, item.Key);
                return true;
            }

            return false;
        }

        public void Clear()
        {
            var priorKeys = this.dictionary.Keys.ToArray();
            this.dictionary.Clear();
            foreach (var key in priorKeys)
            {
                this.InvokeMapChanged(CollectionChange.ItemRemoved, key);
            }
        }

        public bool ContainsKey(string key)
        {
            return this.dictionary.ContainsKey(key);
        }

        public bool TryGetValue(string key, out object value)
        {
            return this.dictionary.TryGetValue(key, out value);
        }

        public bool Contains(KeyValuePair<string, object> item)
        {
            return this.dictionary.Contains(item);
        }

        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return this.dictionary.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.dictionary.GetEnumerator();
        }

        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            int arraySize = array.Length;
            foreach (var pair in this.dictionary)
            {
                if (arrayIndex >= arraySize)
                {
                    break;
                }

                array[arrayIndex++] = pair;
            }
        }

        private void InvokeMapChanged(CollectionChange change, string key)
        {
            var eventHandler = this.MapChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new ObservableDictionaryChangedEventArgs(change, key));
            }
        }

        private class ObservableDictionaryChangedEventArgs : IMapChangedEventArgs<string>
        {
            public ObservableDictionaryChangedEventArgs(CollectionChange change, string key)
            {
                this.CollectionChange = change;
                this.Key = key;
            }

            public CollectionChange CollectionChange { get; private set; }

            public string Key { get; private set; }
        }
    }
}
