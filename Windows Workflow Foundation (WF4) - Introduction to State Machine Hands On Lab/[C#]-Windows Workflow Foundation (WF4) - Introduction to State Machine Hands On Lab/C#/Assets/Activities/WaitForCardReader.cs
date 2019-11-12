// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WaitForCardReader.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    using System;
    using System.Activities;

    /// <summary>
    /// An activity that waits for the ATM Card Reader
    /// </summary>
    /// <remarks>
    /// The Card Reader device driver emits an event with data about the card read
    ///   This activity will create a bookmark to wait for the event and when resumed
    ///   return the resulting data to the workflow.
    /// It creates a bookmark using the name of the CardReaderEvent to indicate what
    /// it is waiting for.
    /// </remarks>
    public sealed class WaitForCardReader : NativeActivity<CardReaderResult>
    {
        #region Constants and Fields

        /// <summary>
        ///   The CardReader callback.
        /// </summary>
        private BookmarkCallback cardReaderCallback;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets CardReaderEvent.
        /// </summary>
        public CardReaderEvent CardReaderEvent { get; set; }

        /// <summary>
        ///   Gets a value indicating whether CanInduceIdle.
        /// </summary>
        protected override bool CanInduceIdle
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        ///   Gets CardReaderCallback.
        /// </summary>
        private BookmarkCallback CardReaderCallback
        {
            get
            {
                return this.cardReaderCallback ??
                       (this.cardReaderCallback = new BookmarkCallback(this.OnCardReaderCallback));
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The cache metadata.
        /// </summary>
        /// <param name="metadata">
        /// The metadata.
        /// </param>
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            metadata.RequireExtension(typeof(AtmMachine));
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Execute(NativeActivityContext context)
        {
            // CardReaderEvent.None is a no op
            if (this.CardReaderEvent != CardReaderEvent.None)
            {
                context.CreateBookmark(this.CardReaderEvent.ToString(), this.CardReaderCallback);
            }
        }

        /// <summary>
        /// The on CardReader callback.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <param name="bookmark">
        /// The bookmark.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <exception cref="InvalidOperationException">
        /// </exception>
        private void OnCardReaderCallback(NativeActivityContext context, Bookmark bookmark, object value)
        {
            if (value is CardReaderResult)
            {
                this.Result.Set(context, value as CardReaderResult);
            }
            else if (value != null)
            {
                // Resumed with something else
                throw new InvalidOperationException(
                    "You must resume the CardReader bookmark with a result of type CardReaderResult");
            }
        }

        #endregion
    }
}