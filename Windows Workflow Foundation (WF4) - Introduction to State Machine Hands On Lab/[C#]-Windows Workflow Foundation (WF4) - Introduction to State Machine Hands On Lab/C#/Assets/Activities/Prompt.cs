// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Prompt.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AtmStateMachine.Activities
{
    using System.Activities;
    using System.ComponentModel;

    /// <summary>
    /// The display prompt.
    /// </summary>
    public sealed class Prompt : CodeActivity
    {
        #region Properties

        /// <summary>
        ///   Gets or sets Line.
        /// </summary>
        [DefaultValue(null)]
        public InArgument<byte> Line { get; set; }

        /// <summary>
        ///   Gets or sets Text.
        /// </summary>
        [DefaultValue(null)]
        public InArgument<string> Text { get; set; }

        /// <summary>
        /// Gets or sets Transition.
        /// </summary>
        /// <remarks>
        /// Some prompts also enable a transition.  If the prompt
        /// does not enable a transition the value will be AtmTransition.None
        /// </remarks>
        public AtmTransition Transition { get; set; }

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
            metadata.AddArgument(new RuntimeArgument("Text", typeof(string), ArgumentDirection.In, false));
            metadata.AddArgument(new RuntimeArgument("Line", typeof(byte), ArgumentDirection.In, false));
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Execute(CodeActivityContext context)
        {
            // Obtain the runtime value of the Text input argument
            var atmViewModel = context.GetExtension<IAtmViewModel>();
            var atmPrompt = new AtmPrompt
                {
                    Line = this.Line.Expression == null ? (byte)1 : this.Line.Get(context),
                    Text = this.Text.Get(context),
                    Transition = this.Transition
                };

            atmViewModel.Prompt(atmPrompt);
        }

        #endregion
    }
}