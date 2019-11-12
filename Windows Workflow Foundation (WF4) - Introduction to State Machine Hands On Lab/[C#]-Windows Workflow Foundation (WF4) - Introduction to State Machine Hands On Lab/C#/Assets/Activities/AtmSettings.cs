// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtmSettings.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    using System;

    /// <summary>
    /// The atm settings.
    /// </summary>
    public class AtmSettings
    {
        #region Properties

        /// <summary>
        /// Gets or sets Timeout.
        /// </summary>
        public TimeSpan Timeout { get; set; }

        #endregion
    }
}