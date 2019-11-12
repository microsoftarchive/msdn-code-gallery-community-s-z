// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Data.Common;
using EFProviderWrapperToolkit;

namespace EFTracingProvider
{
    /// <summary>
    /// EFTracingProvider factory.
    /// </summary>
    [CLSCompliant(false)]
    public class EFTracingProviderFactory : DbProviderFactoryBase
    {
        /// <summary>
        /// Gets or sets the singleton instance of the provider.
        /// </summary>
        /// <value>The instance.</value>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Factory is immutale.")]
        public static readonly EFTracingProviderFactory Instance = new EFTracingProviderFactory(EFTracingProviderServices.Instance);

        /// <summary>
        /// Initializes a new instance of the EFTracingProviderFactory class.
        /// </summary>
        /// <param name="providerServices">The provider services.</param>
        public EFTracingProviderFactory(DbProviderServices providerServices)
            : base(providerServices)
        {
        }

        /// <summary>
        /// Returns a new instance of the provider's class that implements the <see cref="T:System.Data.Common.DbConnection"/> class.
        /// </summary>
        /// <returns>
        /// A new instance of <see cref="T:System.Data.Common.DbConnection"/>.
        /// </returns>
        public override DbConnection CreateConnection()
        {
            return new EFTracingConnection();
        }
    }
}
