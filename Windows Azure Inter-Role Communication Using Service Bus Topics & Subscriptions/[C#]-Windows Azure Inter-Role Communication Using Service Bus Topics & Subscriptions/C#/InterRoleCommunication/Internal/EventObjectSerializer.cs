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
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Internal
{
    #region Using references
    using System;
    using System.IO;
    using System.Xml;
    using System.Runtime.Serialization;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;
    #endregion

    internal sealed class EventObjectSerializer : XmlObjectSerializer
    {
        private readonly DataContractSerializer dataContractSerializer;
        private readonly SharedTypeResolver resolver;

        public EventObjectSerializer(Type type)
        {
            this.dataContractSerializer = new DataContractSerializer(type);
            this.resolver = new SharedTypeResolver();
        }

        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            return this.dataContractSerializer.IsStartObject(reader);
        }

        public override object ReadObject(Stream stream)
        {
            Guard.ArgumentNotNull(stream, "stream");

            return this.ReadObject(XmlDictionaryReader.CreateBinaryReader(stream, XmlDictionaryReaderQuotas.Max));
        }

        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            return this.dataContractSerializer.ReadObject(reader, verifyObjectName, this.resolver);
        }

        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
            this.dataContractSerializer.WriteEndObject(writer);
        }

        public override void WriteObject(Stream stream, object graph)
        {
            Guard.ArgumentNotNull(stream, "stream");

            XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(stream, null, null, false);
            this.dataContractSerializer.WriteObject(writer, graph, this.resolver);
            writer.Flush();
        }

        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
            this.dataContractSerializer.WriteObjectContent(writer, graph);
        }

        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
            this.dataContractSerializer.WriteStartObject(writer, graph);
        }

        #region SharedTypeResolver class implementation
        private class SharedTypeResolver : DataContractResolver
        {
            private readonly XmlDictionary dictionary = new XmlDictionary();

            public override bool TryResolveType(Type dataContractType, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
            {
                if (!knownTypeResolver.TryResolveType(dataContractType, declaredType, null, out typeName, out typeNamespace))
                {
                    typeName = this.dictionary.Add(dataContractType.FullName);
                    typeNamespace = this.dictionary.Add(dataContractType.Assembly.FullName);
                }

                return true;
            }

            public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
            {
                return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, null) ?? Type.GetType(typeName + ", " + typeNamespace);
            }
        } 
        #endregion
    }
}
