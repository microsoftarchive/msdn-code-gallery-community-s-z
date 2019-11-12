// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ControlCamera.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    using System.Activities;

    /// <summary>
    /// The enable camera.
    /// </summary>
    public sealed class ControlCamera : CodeActivity
    {
        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether Record.
        /// </summary>
        public bool Record { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The cache metadata.
        /// </summary>
        /// <param name="metadata">
        /// The metadata.
        /// </param>
        protected override void CacheMetadata(CodeActivityMetadata metadata)
        {
            metadata.RequireExtension(typeof(IAtmViewModel));
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Execute(CodeActivityContext context)
        {
            var atm = context.GetExtension<IAtmViewModel>();
            atm.ControlCamera(this.Record);
        }

        #endregion
    }
}