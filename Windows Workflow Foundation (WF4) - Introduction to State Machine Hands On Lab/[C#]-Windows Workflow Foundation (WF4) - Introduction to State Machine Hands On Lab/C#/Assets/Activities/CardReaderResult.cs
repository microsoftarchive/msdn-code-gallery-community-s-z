// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardReaderResult.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    /// <summary>
    /// The card reader result.
    /// </summary>
    public class CardReaderResult
    {
        #region Properties

        /// <summary>
        /// Gets or sets CardStatus.
        /// </summary>
        public CardStatus CardStatus { get; set; }

        /// <summary>
        /// Gets or sets Event.
        /// </summary>
        public CardReaderEvent Event { get; set; }

        #endregion
    }
}