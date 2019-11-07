// Copyright (c) Microsoft Corporation.  All rights reserved.

using System.Data.Common;
using System.Data.Common.CommandTrees;
using EFProviderWrapperToolkit;

namespace EFTracingProvider
{
    /// <summary>
    /// Implementation of <see cref="DbProviderServices"/> for EFTracingProvider.
    /// </summary>
    internal class EFTracingProviderServices : DbProviderServicesBase
    {
        /// <summary>
        /// Initializes static members of the EFTracingProviderServices class.
        /// </summary>
        static EFTracingProviderServices()
        {
            Instance = new EFTracingProviderServices();
        }

        /// <summary>
        /// Initializes a new instance of the EFTracingProviderServices class.
        /// </summary>
        public EFTracingProviderServices()
        {
        }

        /// <summary>
        /// Gets the singleton instance.
        /// </summary>
        /// <value>The singleton instance.</value>
        public static EFTracingProviderServices Instance { get; private set; }

        /// <summary>
        /// Gets the default name of the wrapped provider.
        /// </summary>
        /// <returns>
        /// Default name of the wrapped provider (to be used when
        /// provider is not specified in the connction string).
        /// </returns>
        protected override string DefaultWrappedProviderName
        {
            get { return EFTracingProviderConfiguration.DefaultWrappedProvider; }
        }

        /// <summary>
        /// Gets the provider invariant iname.
        /// </summary>
        /// <returns>Provider invariant name.</returns>
        protected override string ProviderInvariantName
        {
            get { return "EFTracingProvider"; }
        }

        /// <summary>
        /// Creates the command definition wrapper.
        /// </summary>
        /// <param name="wrappedCommandDefinition">The wrapped command definition.</param>
        /// <param name="commandTree">The command tree.</param>
        /// <returns>
        /// The <see cref="DbCommandDefinitionWrapper"/> object.
        /// </returns>
        public override DbCommandDefinitionWrapper CreateCommandDefinitionWrapper(DbCommandDefinition wrappedCommandDefinition, DbCommandTree commandTree)
        {
            return new DbCommandDefinitionWrapper(wrappedCommandDefinition, commandTree, (cmd, def) => new EFTracingCommand(cmd, def));
        }
   }
}