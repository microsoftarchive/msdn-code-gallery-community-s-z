// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardReaderEvent.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    /// <summary>
    /// The card reader event.
    /// </summary>
    public enum CardReaderEvent
    {
        /// <summary>
        ///   The none.
        /// </summary>
        None, 

        /// <summary>
        ///   The card inserted.
        /// </summary>
        CardInserted, 

        /// <summary>
        ///   The card removed.
        /// </summary>
        CardRemoved
    }
}