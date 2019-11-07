//=======================================================================================
// Microsoft Windows Azure Customer Advisory Team (CAT) Best Practices Series
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://windowsazurecat.com/. 
//
//=======================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework
{
    #region Using statements
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml;
    using System.Text;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Security.Cryptography;
    #endregion

    /// <summary>
    /// Provides a set of common methods used by framework components.
    /// </summary>
    public static class FrameworkUtility
    {
        /// <summary>
        /// Returns an instance of the declarative attribute of type <typeparamref name="T"/> which is applied to the .NET type of the specified object.
        /// </summary>
        /// <typeparam name="T">The type of the declarative attribute. Must inherit from the <see cref="System.Attribute"/> class.</typeparam>
        /// <param name="obj">The object supplying the declarative attribute.</param>
        /// <returns>The instance of the declarative attribute of type <typeparamref name="T"/>, or a null reference if no attribute matching the specified type was found.</returns>
        public static T GetDeclarativeAttribute<T>(object obj) where T : class
        {
            Guard.ArgumentNotNull(obj, "obj");

            return GetDeclarativeAttribute<T>(obj.GetType());
        }

        /// <summary>
        /// Returns an instance of the declarative attribute of type <typeparamref name="T"/> which is applied to the specified .NET type.
        /// </summary>
        /// <typeparam name="T">The type of the declarative attribute. Must inherit from the <see cref="System.Attribute"/> class.</typeparam>
        /// <param name="type">The .NET type supplying the declarative attribute.</param>
        /// <returns>The instance of the declarative attribute of type <typeparamref name="T"/>, or a null reference if no attribute matching the specified type <typeparamref name="T"/> was found.</returns>
        public static T GetDeclarativeAttribute<T>(Type type) where T : class
        {
            IList<T> attributes = GetDeclarativeAttributes<T>(type);
            return attributes.FirstOrDefault<T>();
        }

        /// <summary>
        /// Returns instances of the declarative attribute of type <typeparamref name="T"/> which is applied to the specified .NET type.
        /// </summary>
        /// <typeparam name="T">The type of the declarative attribute. Must inherit from the <see cref="System.Attribute"/> class.</typeparam>
        /// <param name="type">The .NET type supplying the declarative attribute.</param>
        /// <returns>A list containing declarative attribute of type <typeparamref name="T"/>, or an empty list if no attributes matching the specified type <typeparamref name="T"/> were found.</returns>
        public static IList<T> GetDeclarativeAttributes<T>(Type type) where T : class
        {
            Guard.ArgumentNotNull(type, "type");

            object[] customAttributes = type.GetCustomAttributes(typeof(T), true);
            IList<T> attributes = new List<T>();

            if (customAttributes != null && customAttributes.Length > 0)
            {
                foreach (object customAttr in customAttributes)
                {
                    if (customAttr.GetType() == typeof(T))
                    {
                        attributes.Add(customAttr as T);
                    }
                }
            }
            else
            {
                Type[] interfaces = type.GetInterfaces();

                if (interfaces != null && interfaces.Length > 0)
                {
                    foreach (object[] customAttrs in interfaces.Select(i => i.GetCustomAttributes(typeof(T), false)))
                    {
                        if (customAttrs != null && customAttrs.Length > 0)
                        {
                            foreach (object customAttr in customAttrs)
                            {
                                attributes.Add(customAttr as T);
                            }
                        }
                    }
                }
            }

            return attributes;
        }

        /// <summary>
        /// Converts the specified list of values into a fixed-length hash.
        /// </summary>
        /// <param name="values">One or more values to be hashed.</param>
        /// <returns>An hash value that corresponds to the specified combination of values.</returns>
        public static string GetHashedValue(params string[] values)
        {
            Guard.ArgumentNotNull(values, "values");
            Guard.ArgumentNotZeroOrNegativeValue(values.Length, "values.Length");

            using (HashAlgorithm md5 = new MD5CryptoServiceProvider())
            {
                byte[] originalBytes = Encoding.UTF8.GetBytes(String.Concat(values));
                byte[] encodedBytes = md5.ComputeHash(originalBytes);

                return BitConverter.ToString(encodedBytes).Replace("-", String.Empty);
            }
        }
    }
}
