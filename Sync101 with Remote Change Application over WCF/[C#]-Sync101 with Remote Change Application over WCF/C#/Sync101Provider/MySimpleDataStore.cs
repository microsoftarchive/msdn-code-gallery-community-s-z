// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Synchronization;
using Microsoft.Synchronization.MetadataStorage;

namespace Sync101
{
    [Serializable()]
    public class MySimpleDataStore
    {
        //This is our sample in memory data store which for simplicity stores instances of ItemData referenced 
        //by identifiers of type 'Guid'
        private SortedDictionary<Guid, ItemData> _store = new SortedDictionary<Guid, ItemData>();

        public Guid CreateItem(ItemData value)
        {
            Guid id = Guid.NewGuid();
            return CreateItem(value, id);
        }

        public Guid CreateItem(ItemData value, Guid id)
        {
            value.TimeStamp = (ulong)DateTime.Now.Ticks;
            _store[id] = value; // Assume value passed in is already copied instance
            
            return id;
        }

        public bool DeleteItem(Guid id)
        {
            return _store.Remove(id);
        }

        public ulong UpdateItem(Guid id, ItemData value)
        {
            ulong timeStamp = (ulong)DateTime.Now.Ticks;
            value.TimeStamp = timeStamp;
            _store[id] = value; // Assume value passed in is already copied instance

            return timeStamp;
        }

        //Access to items in the data store
        public ItemData Get(Guid id)
        {
            return _store[id];
        }

        //Enumerate the item Ids
        public SortedDictionary<Guid, ItemData>.KeyCollection Ids
        {
            get { return _store.Keys; }
        }

        public override string ToString()
        {
            StringBuilder buffer = new StringBuilder();
            foreach (Guid id in _store.Keys)
            {
                //Print out the ID and the data associated
                buffer.AppendFormat("[{0}]: {1}", id, _store[id]);
                buffer.Append(Environment.NewLine);
            }

            return buffer.ToString();
        }

        /// <summary>
        /// Writing a MySimpleDataStore to a file
        /// </summary>
        public void WriteStoreToFile(string folderPath, string storeName)
        {
            string fileName = folderPath + "\\" + storeName.ToString() + ".Store";
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                bf.Serialize(fs, this);
            }
        }

        /// <summary>
        /// Reading a MySimpleDataStore from file
        /// </summary>
        public static MySimpleDataStore ReadStoreFromFile(string folderPath, string storeName)
        {
            string fileName = folderPath + "\\" + storeName.ToString() + ".Store";
            MySimpleDataStore mySimpleDataStore;
            BinaryFormatter bf = new BinaryFormatter();

            if (File.Exists(fileName))
            {
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    mySimpleDataStore = bf.Deserialize(fs) as MySimpleDataStore;
                }
            }
            else
            {
                mySimpleDataStore = new MySimpleDataStore();
            }

            return mySimpleDataStore;
        }
    }

    //The items stored in MySimpleDataStore are collections of name/value pairs.
    [Serializable()]
    public class ItemData
    {
        private Dictionary<string, string> _data;
        private ulong _timestamp;

        public ItemData()
        {
            _data = new Dictionary<string, string>();
            _timestamp = (ulong)DateTime.Now.Ticks;
        }

        //Create the item with a single initial pair
        public ItemData(string name, string value)
            : this()
        {
            this[name] = value;
        }

        public ItemData(ItemData src)
        {
            //Deep copy the data, but create a new timestamp value.
            _data = new Dictionary<string, string>(src._data);
            _timestamp = (ulong)DateTime.Now.Ticks;
        }

        //indexed access to the data items.
        public string this[string key]
        {
            get { return _data[key]; }
            set { _data[key] = value; }
        }

        internal ulong TimeStamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        public ItemData Merge(ItemData other)
        {
            ItemData result = new ItemData();

            foreach (string key in other._data.Keys)
            {
                if (this._data.ContainsKey(key))
                {
                    // merge the value if it exists in both objects
                    result._data[key] = string.Concat(this._data[key], other._data[key]);
                }
                else
                {
                    //Just add the value since it only exists inone.
                    result._data[key] = other._data[key];
                }
            }
            foreach (string key in this._data.Keys)
            {
                if (!other._data.ContainsKey(key))
                {
                    //Just add the value since it only exists inone.
                    result._data[key] = this._data[key];
                }
            }
            return result;
        }

        //List all the pairs for test and debugging purposes.
        public override string ToString()
        {
            string delim = "";
            StringBuilder builder = new StringBuilder();

            foreach (string name in _data.Keys)
            {
                builder.Append(delim);
                builder.Append(name);
                builder.Append(": ");
                builder.Append(this[name]);
                delim = "; ";
            }
            return builder.ToString();
        }
    }
}
