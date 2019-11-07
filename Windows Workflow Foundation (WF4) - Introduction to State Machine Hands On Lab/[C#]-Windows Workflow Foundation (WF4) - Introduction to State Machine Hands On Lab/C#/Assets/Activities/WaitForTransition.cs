// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WaitForTransition.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    using System;
    using System.Activities;

    /// <summary>
    /// The wait for transition.
    /// </summary>
    public sealed class WaitForTransition : NativeActivity<AtmTransitionResult>
    {
        #region Constants and Fields

        /// <summary>
        /// The transition callback.
        /// </summary>
        private BookmarkCallback transitionCallback;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets AtmTransition.
        /// </summary>
        public AtmTransition AtmTransition { get; set; }

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
        /// Gets TransitionCallback.
        /// </summary>
        private BookmarkCallback TransitionCallback
        {
            get
            {
                return this.transitionCallback ?? (this.transitionCallback = new BookmarkCallback(this.OnTransitionCallback));
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
            context.CreateBookmark(this.AtmTransition.ToString(), this.TransitionCallback);
        }

        /// <summary>
        /// The on transition callback.
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
        private void OnTransitionCallback(NativeActivityContext context, Bookmark bookmark, object value)
        {
            if (value is AtmTransitionResult)
            {
                this.Result.Set(context, value as AtmTransitionResult);
            }
            else if (value != null)
            {
                // Resumed with something else
                throw new InvalidOperationException(
                    "You must resume AtmTransition bookmarks with a result of type AtmTransitionResult");
            }
        }

        #endregion
    }
}