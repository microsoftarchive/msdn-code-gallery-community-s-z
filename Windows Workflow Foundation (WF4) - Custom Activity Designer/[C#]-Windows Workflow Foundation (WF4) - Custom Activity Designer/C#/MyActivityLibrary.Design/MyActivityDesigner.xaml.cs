namespace MyActivityLibrary.Design
{
    using System.Activities.Presentation.Metadata;
    using System.ComponentModel;
    using System.Drawing;

    /// <summary>
    /// The MyActivity designer.
    /// </summary>
    public partial class MyActivityDesigner
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MyActivityDesigner"/> class.
        /// </summary>
        public MyActivityDesigner()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Registers metadata.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
    public static void RegisterMetadata(AttributeTableBuilder builder)
    {
        builder.AddCustomAttributes(
            typeof(MyActivity), 
            new DesignerAttribute(typeof(MyActivityDesigner)), 
            new DescriptionAttribute("My sample activity"), 
            new ToolboxBitmapAttribute(typeof(MyActivity), "QuestionMark.png"));
    }

        #endregion
    }
}