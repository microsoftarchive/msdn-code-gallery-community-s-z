// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InitializeAtm.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    using System.Activities;

    /// <summary>
    /// Initializes the ATM Machine Hardware
    /// </summary>
    public sealed class InitializeAtm : CodeActivity
    {
        #region Methods

        /// <summary>
        /// The cache metadata.
        /// </summary>
        /// <param name="metadata">
        /// The metadata.
        /// </param>
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            metadata.RequireExtension(typeof(AtmMachine));
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Execute(CodeActivityContext context)
        {
            var atm = context.GetExtension<AtmMachine>();
            atm.InitializeHardware();
        }

        #endregion
    }
}