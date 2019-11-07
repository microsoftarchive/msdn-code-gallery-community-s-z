// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AtmPrompt.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    using System;

    /// <summary>
    /// The atm prompt.
    /// </summary>
    public class AtmPrompt
    {
        #region Constants and Fields

        /// <summary>
        ///   The line to prompt.
        /// </summary>
        private byte line;

        /// <summary>
        ///   The prompt text.
        /// </summary>
        private string text;

        #endregion

        #region Properties

        /// <summary>
        ///   Gets or sets Line.
        /// </summary>
        /// <exception cref = "ArgumentOutOfRangeException">
        ///   The value is not between 1 and 4
        /// </exception>
        public byte Line
        {
            get
            {
                return this.line;
            }

            set
            {
                if ((value < 1) || (value > 4))
                {
                    throw new ArgumentOutOfRangeException("value", SR.Line_must_be_a_value_between_1_and_4);
                }

                this.line = value;
            }
        }

        /// <summary>
        ///   Gets or sets Text.
        /// </summary>
        public string Text
        {
            get
            {
                // If no text is provided, use the name of the transition
                if (string.IsNullOrWhiteSpace(this.text))
                {
                    this.text = this.Transition.ToString();
                }

                return this.text;
            }

            set
            {
                this.text = value;
            }
        }

        /// <summary>
        ///   Gets or sets Transition.
        /// </summary>
        /// <remarks>
        ///   Some prompts also enable a transition
        /// </remarks>
        public AtmTransition Transition { get; set; }

        #endregion
    }
}