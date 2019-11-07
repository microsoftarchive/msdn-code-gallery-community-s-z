// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardStatus.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    /// <summary>
    /// The card status.
    /// </summary>
    public enum CardStatus
    {
        /// <summary>
        ///   The unknown.
        /// </summary>
        Unknown, 

        /// <summary>
        ///   The valid.
        /// </summary>
        Valid, 

        /// <summary>
        ///   The invalid.
        /// </summary>
        Invalid, 
    }
}