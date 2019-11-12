// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace DesignerWorkbench
{
    using System;
    using System.Activities;
    using System.Activities.Core.Presentation;
    using System.Activities.Presentation;
    using System.Activities.Presentation.Metadata;
    using System.Activities.Presentation.Toolbox;
    using System.Activities.Statements;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Windows;
    using System.Windows.Input;

    using DesignerWorkbench.Properties;

    using Microsoft.Win32;

    using MyActivityLibrary;
    using MyActivityLibrary.Design;

    /// <summary>
    /// The main view model.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        #region Constants and Fields

        /// <summary>
        ///   The template xaml.
        /// </summary>
        private const string TemplateXaml = "template.xaml";

        /// <summary>
        ///   The untitled xaml.
        /// </summary>
        private const string UntitledXAML = "Untitled.xaml";

        /// <summary>
        ///   The file name.
        /// </summary>
        private string fileName;

        /// <summary>
        ///   The status.
        /// </summary>
        private string status;

        /// <summary>
        ///   The title.
        /// </summary>
        private string title = Resources.Workflow_Designer_Workbench;

        /// <summary>
        ///   The workflow designer.
        /// </summary>
        private WorkflowDesigner workflowDesigner;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///   Initializes a new instance of the <see cref = "MainViewModel" /> class.
        /// </summary>
        internal MainViewModel()
        {
            (new DesignerMetadata()).Register();
            MyActivityLibraryMetadata.RegisterAll();
            LoadToolboxIconsForBuiltInActivities();
            this.ToolboxPanel = CreateToolbox();
            this.ExitCommand = new RelayCommand(this.ExecuteExit, CanExecuteExit);
            this.OpenCommand = new RelayCommand(this.ExecuteOpen, CanExecuteOpen);
            this.NewCommand = new RelayCommand(this.ExecuteNew, CanExecuteNew);
            this.SaveCommand = new RelayCommand(this.ExecuteSave, CanExecuteSave);
            this.SaveAsCommand = new RelayCommand(this.ExecuteSaveAs, CanExecuteSaveAs);
            this.ExecuteNew(null);
        }

        #endregion

        #region Public Events

        /// <summary>
        ///   The property changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        ///   Gets or sets ExitCommand.
        /// </summary>
        public ICommand ExitCommand { get; set; }

        /// <summary>
        ///   Gets FileName.
        /// </summary>
        public string FileName
        {
            get
            {
                return this.fileName;
            }

            private set
            {
                this.fileName = value;
                this.Title = string.Format("{0} - {1}", Resources.Workflow_Designer_Workbench, this.FileName);
            }
        }

        /// <summary>
        ///   Gets or sets NewCommand.
        /// </summary>
        public ICommand NewCommand { get; set; }

        /// <summary>
        ///   Gets or sets OpenCommand.
        /// </summary>
        public ICommand OpenCommand { get; set; }

        /// <summary>
        ///   Gets or sets SaveAsCommand.
        /// </summary>
        public ICommand SaveAsCommand { get; set; }

        /// <summary>
        ///   Gets or sets SaveCommand.
        /// </summary>
        public ICommand SaveCommand { get; set; }

        /// <summary>
        ///   Gets or sets Status.
        /// </summary>
        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
                this.NotifyChanged("Status");
            }
        }

        /// <summary>
        ///   Gets Title.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            private set
            {
                this.title = value;
                this.NotifyChanged("Title");
            }
        }

        /// <summary>
        ///   Gets ToolboxPanel.
        /// </summary>
        public object ToolboxPanel { get; private set; }

        /// <summary>
        ///   Gets WorkflowDesigner.
        /// </summary>
        public WorkflowDesigner WorkflowDesigner
        {
            get
            {
                return this.workflowDesigner;
            }

            private set
            {
                this.workflowDesigner = value;
                this.NotifyChanged("WorkflowDesignerPanel");
                this.NotifyChanged("WorkflowPropertyPanel");
            }
        }

        /// <summary>
        ///   Gets WorkflowDesignerPanel.
        /// </summary>
        public object WorkflowDesignerPanel
        {
            get
            {
                return this.WorkflowDesigner.View;
            }
        }

        /// <summary>
        ///   Gets WorkflowPropertyPanel.
        /// </summary>
        public object WorkflowPropertyPanel
        {
            get
            {
                return this.WorkflowDesigner.PropertyInspectorView;
            }
        }

        /// <summary>
        ///   Gets XAML.
        /// </summary>
        public string XAML
        {
            get
            {
                if (this.WorkflowDesigner.Text != null)
                {
                    this.WorkflowDesigner.Flush();
                    return this.WorkflowDesigner.Text;
                }

                return null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The view closed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void ViewClosed(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// The view closing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        public void ViewClosing(object sender, CancelEventArgs e)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Notify that a property has changed
        /// </summary>
        /// <param name="property">
        /// The property that changed
        /// </param>
        internal void NotifyChanged(string property)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        /// <summary>
        /// The create toolbox bitmap attribute for activity.
        /// </summary>
        /// <param name="builder">
        /// The builder.
        /// </param>
        /// <param name="resourceReader">
        /// The resource reader.
        /// </param>
        /// <param name="builtInActivityType">
        /// The built in activity type.
        /// </param>
        private static void CreateToolboxBitmapAttributeForActivity(
            AttributeTableBuilder builder, ResourceReader resourceReader, Type builtInActivityType)
        {
            var bitmap = ExtractBitmapResource(
                resourceReader, 
                builtInActivityType.IsGenericType ? builtInActivityType.Name.Split('`')[0] : builtInActivityType.Name);

            if (bitmap == null)
            {
                return;
            }

            var tbaType = typeof(ToolboxBitmapAttribute);

            var imageType = typeof(Image);

            var constructor = tbaType.GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { imageType, imageType }, null);

            var tba = constructor.Invoke(new object[] { bitmap, bitmap }) as ToolboxBitmapAttribute;

            builder.AddCustomAttributes(builtInActivityType, tba);
        }

        /// <summary>
        /// The extract bitmap resource.
        /// </summary>
        /// <param name="resourceReader">
        /// The resource reader.
        /// </param>
        /// <param name="bitmapName">
        /// The bitmap name.
        /// </param>
        /// <returns>
        /// The bitmap
        /// </returns>
        private static Bitmap ExtractBitmapResource(ResourceReader resourceReader, string bitmapName)
        {
            var dictEnum = resourceReader.GetEnumerator();

            Bitmap bitmap = null;

            while (dictEnum.MoveNext())
            {
                if (Equals(dictEnum.Key, bitmapName))
                {
                    bitmap = dictEnum.Value as Bitmap;

                    if (bitmap != null)
                    {
                        var pixel = bitmap.GetPixel(bitmap.Width - 1, 0);

                        bitmap.MakeTransparent(pixel);
                    }

                    break;
                }
            }

            return bitmap;
        }

        /// <summary>
        /// The load toolbox icons for built in activities.
        /// </summary>
        private static void LoadToolboxIconsForBuiltInActivities()
        {
            try
            {
                var sourceAssembly = Assembly.LoadFrom(@"Lib\Microsoft.VisualStudio.Activities.dll");

                var builder = new AttributeTableBuilder();

                if (sourceAssembly != null)
                {
                    var stream =
                        sourceAssembly.GetManifestResourceStream(
                            "Microsoft.VisualStudio.Activities.Resources.resources");
                    if (stream != null)
                    {
                        var resourceReader = new ResourceReader(stream);

                        foreach (var type in
                            typeof(Activity).Assembly.GetTypes().Where(
                                t => t.Namespace == "System.Activities.Statements"))
                        {
                            CreateToolboxBitmapAttributeForActivity(builder, resourceReader, type);
                        }
                    }
                }

                MetadataStore.AddAttributeTable(builder.CreateTable());
            }
            catch (FileNotFoundException)
            {
                // Ignore - will use default icons
            }
        }

        /// <summary>
        /// The can execute exit.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// True if the app can exit
        /// </returns>
        private static bool CanExecuteExit(object obj)
        {
            return true;
        }

        /// <summary>
        /// The can execute new.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// True if the execute new command can be invoked
        /// </returns>
        private static bool CanExecuteNew(object obj)
        {
            return true;
        }

        /// <summary>
        /// The can execute open.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// True if can open
        /// </returns>
        private static bool CanExecuteOpen(object obj)
        {
            return true;
        }

        /// <summary>
        /// The can execute save.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// true if can save
        /// </returns>
        private static bool CanExecuteSave(object obj)
        {
            return true;
        }

        /// <summary>
        /// The can execute save as.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <returns>
        /// true if can save as
        /// </returns>
        private static bool CanExecuteSaveAs(object obj)
        {
            return true;
        }

        /// <summary>
        /// The create toolbox.
        /// </summary>
        /// <returns>
        /// The toolbox control
        /// </returns>
        private static ToolboxControl CreateToolbox()
        {
            var toolboxControl = new ToolboxControl();

            toolboxControl.Categories.Add(
                new ToolboxCategory("Control Flow")
                    {
                        new ToolboxItemWrapper(typeof(DoWhile)), 
                        new ToolboxItemWrapper(typeof(ForEach<>)), 
                        new ToolboxItemWrapper(typeof(If)), 
                        new ToolboxItemWrapper(typeof(Parallel)), 
                        new ToolboxItemWrapper(typeof(ParallelForEach<>)), 
                        new ToolboxItemWrapper(typeof(Pick)), 
                        new ToolboxItemWrapper(typeof(PickBranch)), 
                        new ToolboxItemWrapper(typeof(Sequence)), 
                        new ToolboxItemWrapper(typeof(Switch<>)), 
                        new ToolboxItemWrapper(typeof(While)), 
                    });

            toolboxControl.Categories.Add(
                new ToolboxCategory("Primitives")
                    {
                        new ToolboxItemWrapper(typeof(Assign)), 
                        new ToolboxItemWrapper(typeof(Delay)), 
                        new ToolboxItemWrapper(typeof(InvokeMethod)), 
                        new ToolboxItemWrapper(typeof(WriteLine)), 
                    });

            toolboxControl.Categories.Add(
                new ToolboxCategory("Error Handling")
                    {
                        new ToolboxItemWrapper(typeof(Rethrow)), 
                        new ToolboxItemWrapper(typeof(Throw)), 
                        new ToolboxItemWrapper(typeof(TryCatch)), 
                    });

            toolboxControl.Categories.Add(
                new ToolboxCategory("MyActivityLibrary") { new ToolboxItemWrapper(typeof(MyActivity)), });

            return toolboxControl;
        }

        /// <summary>
        /// The execute exit.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void ExecuteExit(object obj)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// The execute new.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void ExecuteNew(object obj)
        {
            this.WorkflowDesigner = new WorkflowDesigner();
            this.WorkflowDesigner.ModelChanged += this.WorkflowDesignerModelChanged;
            if (File.Exists(TemplateXaml))
            { 
                this.WorkflowDesigner.Load(TemplateXaml);
            }
            else
            {
                this.WorkflowDesigner.Load(new Sequence());
            }

            this.WorkflowDesigner.Flush();
            this.FileName = UntitledXAML;
            this.Status = string.Format("Created new workflow from template {0}", TemplateXaml);
        }

        /// <summary>
        /// The execute open.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void ExecuteOpen(object obj)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog(Application.Current.MainWindow).Value)
            {
                this.LoadWorkflow(openFileDialog.FileName);
            }
        }

        /// <summary>
        /// The execute save.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void ExecuteSave(object obj)
        {
            if (this.FileName == UntitledXAML)
            {
                this.ExecuteSaveAs(obj);
            }
            else
            {
                this.Save();
            }
        }

        /// <summary>
        /// The execute save as.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        private void ExecuteSaveAs(object obj)
        {
            var saveFileDialog = new SaveFileDialog
                {
                    AddExtension = true, 
                    DefaultExt = "xaml", 
                    FileName = this.FileName, 
                    Filter = "xaml files (*.xaml) | *.xaml;*.xamlx| All Files | *.*"
                };

            if (saveFileDialog.ShowDialog().Value)
            {
                this.FileName = saveFileDialog.FileName;
                this.Save();
            }
        }

        /// <summary>
        /// The load workflow.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        private void LoadWorkflow(string name)
        {
            this.ResolveImportedAssemblies(name);
            this.FileName = name;
            this.WorkflowDesigner = new WorkflowDesigner();
            this.WorkflowDesigner.ModelChanged += this.WorkflowDesignerModelChanged;
            this.WorkflowDesigner.Load(name);
        }

        /// <summary>
        /// The locate.
        /// </summary>
        /// <param name="xamlClrRef">
        /// The xaml clr ref.
        /// </param>
        private void Locate(XamlClrRef xamlClrRef)
        {
            this.Status = string.Format("Locate referenced assembly {0}", xamlClrRef.CodeBase);
            var openFileDialog = new OpenFileDialog
                {
                    FileName = xamlClrRef.CodeBase, 
                    CheckFileExists = true, 
                    Filter = "Assemblies (*.dll;*.exe)|*.dll;*.exe|All Files|*.*", 
                    Title = this.Status
                };

            if (openFileDialog.ShowDialog(Application.Current.MainWindow).Value)
            {
                if (!xamlClrRef.Load(openFileDialog.FileName))
                {
                    MessageBox.Show("Error loading assembly");
                }
            }
        }

        /// <summary>
        /// The resolve imported assemblies.
        /// </summary>
        /// <param name="name">
        /// The name.
        /// </param>
        private void ResolveImportedAssemblies(string name)
        {
            var references = XamlClrReferences.Load(name);

            var query = from reference in references.References where !reference.Loaded select reference;
            foreach (var xamlClrRef in query)
            {
                this.Locate(xamlClrRef);
            }
        }

        /// <summary>
        /// The save.
        /// </summary>
        private void Save()
        {
            this.workflowDesigner.Save(this.FileName);
            this.Status = string.Format("Saved workflow file {0}", this.FileName);
        }

        /// <summary>
        /// The workflow designer model changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void WorkflowDesignerModelChanged(object sender, EventArgs e)
        {
            this.NotifyChanged("XAML");
        }

        #endregion
    }
}