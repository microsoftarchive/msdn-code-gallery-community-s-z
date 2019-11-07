// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClearView.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    using System.Activities;

    /// <summary>
    /// The clear view.
    /// </summary>
    public sealed class ClearView : CodeActivity
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
            var atmViewModel = context.GetExtension<IAtmViewModel>();
            atmViewModel.Clear();
        }

        #endregion
    }
}