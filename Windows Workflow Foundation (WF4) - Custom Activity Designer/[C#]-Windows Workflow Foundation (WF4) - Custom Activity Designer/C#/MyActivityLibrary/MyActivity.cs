
namespace MyActivityLibrary
{
    using System.Activities;
    using System.ComponentModel;

/// <summary>
/// MyActivity is a sample to show you how to create the designer
/// </summary>
/// <remarks>
/// TODO: Be sure the build action for your bitmap is set to Embedded Resource 
///   NOTE: The bitmap must be at the same location as the class
///   NOTE: If you use ToolboxBitmap here your activity assembly and those who use it will have to reference System.Drawing
///   Instead you can add the ToolboxBitmapAttribute when you register the metadata to avoid this.
/// [ToolboxBitmap(typeof(MyActivity), "QuestionMark.png")]
/// </remarks>
public sealed class MyActivity : NativeActivity<string>
{
        #region Public Properties

        /// <summary>
        /// Gets or sets Option.
        /// </summary>
        public MyEnum Option { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether TestCode.
        /// </summary>
        public bool TestCode { get; set; }

        /// <summary>
        /// Gets or sets Text.
        /// </summary>
        [DefaultValue(null)]
        public InArgument<string> Text { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        protected override void Execute(NativeActivityContext context)
        {
            this.Result.Set(
                context, 
                string.Format(
                    "Text is {0}, TestCode is {1}, Option is {2}", 
                    context.GetValue(this.Text), 
                    this.TestCode, 
                    this.Option));
        }

        #endregion
    }
}