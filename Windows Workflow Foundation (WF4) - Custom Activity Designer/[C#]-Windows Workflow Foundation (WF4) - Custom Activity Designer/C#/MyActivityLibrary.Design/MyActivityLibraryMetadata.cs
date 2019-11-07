
namespace MyActivityLibrary.Design
{
    using System.Activities.Presentation.Metadata;

    /// <summary>
    /// Designer Metadata registration support
    /// </summary>
    public sealed class MyActivityLibraryMetadata : IRegisterMetadata
    {
        #region Public Methods

        /// <summary>
        /// Registers metadata
        /// </summary>
        public static void RegisterAll()
        {
            var builder = new AttributeTableBuilder();
            MyActivityDesigner.RegisterMetadata(builder);

            // TODO: Other activities can be added here
            MetadataStore.AddAttributeTable(builder.CreateTable());
        }

        /// <summary>
        /// Registers metadata
        /// </summary>
        public void Register()
        {
            RegisterAll();
        }

        #endregion
    }
}