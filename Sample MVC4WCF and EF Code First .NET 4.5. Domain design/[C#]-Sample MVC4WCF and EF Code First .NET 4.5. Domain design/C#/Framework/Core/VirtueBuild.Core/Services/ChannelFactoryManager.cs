#region File Attributes

// AdminWeb  Project: VirtueBuild.Core
// File:  ChannelFactoryManager.cs
// Created By: Slava Khristich 
// Created On: 2013.06.04 
// http://tateeda.com

#endregion

namespace VirtueBuild.Core.Services {
    #region

    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    #endregion

    public class ChannelFactoryManager : IDisposable {

        private static readonly Dictionary<Type, ChannelFactory> _factories = new Dictionary<Type, ChannelFactory>();
        private static readonly object Locker = new object();

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);
        }

        #endregion

        public virtual T CreateChannel<T>() where T : class
        {
            return CreateChannel<T>("*", null);
        }

        public virtual T CreateChannel<T>(string endpointConfigurationName) where T : class
        {
            return CreateChannel<T>(endpointConfigurationName, null);
        }

        public virtual T CreateChannel<T>(string endpointConfigurationName, string endpointAddress) where T : class
        {
            T local = GetFactory<T>(endpointConfigurationName, endpointAddress).CreateChannel();
            ((IClientChannel) local).Faulted += ChannelFaulted;
            ((IClientChannel) local).Open();
            return local;
        }

        protected virtual ChannelFactory<T> GetFactory<T>(string endpointConfigurationName, string endpointAddress)
            where T : class
        {
            lock (Locker) {
                ChannelFactory factory;
                if (!_factories.TryGetValue(typeof (T), out factory)) {
                    factory = CreateFactoryInstance<T>(endpointConfigurationName, endpointAddress);
                    _factories.Add(typeof (T), factory);
                }
                return (factory as ChannelFactory<T>);
            }
        }

        private ChannelFactory CreateFactoryInstance<T>(string endpointConfigurationName, string endpointAddress)
        {
            ChannelFactory factory;
            factory = !string.IsNullOrEmpty(endpointAddress)
                          ? new ChannelFactory<T>(endpointConfigurationName, new EndpointAddress(endpointAddress))
                          : new ChannelFactory<T>(endpointConfigurationName);
            factory.Faulted += FactoryFaulted;
            factory.Open();
            return factory;
        }

        private void ChannelFaulted(object sender, EventArgs e)
        {
            var channel = (IClientChannel) sender;
            try {
                channel.Close();
            }
            catch {
                channel.Abort();
            }
            throw new ApplicationException("Exc_ChannelFailure");
        }

        private void FactoryFaulted(object sender, EventArgs args)
        {
            var factory = (ChannelFactory) sender;
            try {
                factory.Close();
            }
            catch {
                factory.Abort();
            }
            Type[] genericArguments = factory.GetType().GetGenericArguments();
            if (genericArguments.Length == 1) {
                Type key = genericArguments[0];
                if (_factories.ContainsKey(key)) {
                    _factories.Remove(key);
                }
            }
            throw new ApplicationException("Exc_ChannelFactoryFailure");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing) {
                lock (Locker) {
                    foreach (Type type in _factories.Keys) {
                        ChannelFactory factory = _factories[type];

                        if (factory.State == CommunicationState.Faulted) {
                            factory.Abort();
                            continue;
                        }
                        factory.Close();
                    }
                    _factories.Clear();
                }
            }
        }

    }
}