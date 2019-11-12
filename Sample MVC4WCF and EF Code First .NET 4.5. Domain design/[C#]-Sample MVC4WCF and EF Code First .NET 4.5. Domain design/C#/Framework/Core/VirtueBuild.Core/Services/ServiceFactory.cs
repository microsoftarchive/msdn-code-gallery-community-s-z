#region File Attributes

// AdminWeb  Project: VirtueBuild.Core
// File:  ServiceFactory.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Core.Services {
    #region

    using System;
    using System.Collections;
    using System.ServiceModel;

    #endregion

    public abstract class ServiceFactory {

        private static readonly Hashtable Channels = new Hashtable();

        public static T GetService<T>() where T : class
        {
            string key = typeof (T).Name;

            lock (Channels.SyncRoot) {
                if (Channels.ContainsKey(key)) {
                    var clientChannel = ((IClientChannel) Channels[key]);

                    switch (clientChannel.State) {
                        case CommunicationState.Closing:
                        case CommunicationState.Closed:
                        case CommunicationState.Faulted:
                            clientChannel.Abort();
                            clientChannel.Close();
                            Channels.Remove(key);
                            Channels.Add(key, OpenChannel<T>());
                            break;
                    }
                }
                else {
                    Channels.Add(key, OpenChannel<T>());
                }

                return Channels[key] as T;
            }
        }

        private static T OpenChannel<T>() where T : class
        {
            var factory = new ChannelFactory<T>(string.Format("BasicHttpBinding_{0}", typeof (T).Name));

            factory.Open();

            T channel = factory.CreateChannel();

            ((IClientChannel) channel).Faulted += ServiceFactory_Faulted;

            return channel;
        }

        private static void ServiceFactory_Faulted(object sender, EventArgs e)
        {
            var communicationObject = ((ICommunicationObject) sender);

            communicationObject.Abort();
            communicationObject.Close();

            lock (Channels.SyncRoot) {
                communicationObject.Faulted -= ServiceFactory_Faulted;
                Channels.Remove((sender).GetType().Name);
            }
        }

    }
}