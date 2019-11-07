using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace Mm.ExportableDataGrid
{
    public class ExportableDataGrid : DataGrid
    {
        private readonly IExporter _exporter = new CsvExporter(';');
        private readonly ICommand _exportCommand = new RoutedCommand();

        public ExportableDataGrid() 
            : base()
        {
            this.CommandBindings.Add(new CommandBinding(_exportCommand, ExecutedExportCommand, 
                CanExecuteExportCommand));
            this.Loaded += ExportableDataGrid_Loaded;
        }

        private void ExecutedExportCommand(object sender, ExecutedRoutedEventArgs e)
        {
            this.ExportUsingRefection(_exporter, string.Empty);
        }

        private void CanExecuteExportCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.Items.Count > 0;
        }

        private void ExportableDataGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.ContextMenu == null)
                this.ContextMenu = new ContextMenu();

            this.ContextMenu.Loaded += ContextMenu_Loaded;
        }

        private void ContextMenu_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            MenuItem mi = new MenuItem();
            mi.Header = "Export to CSV";
            mi.Command = _exportCommand;

            if (this.ContextMenu.ItemsSource != null)
            {
                CompositeCollection cc = new CompositeCollection();

                CollectionContainer boundCollection = new CollectionContainer();
                boundCollection.Collection = this.ContextMenu.ItemsSource;
                cc.Add(boundCollection);

                CollectionContainer exportCollection = new CollectionContainer();
                List<Control> exportMenuItems = new List<Control>(2);
                exportMenuItems.Add(new Separator());
                exportMenuItems.Add(mi);
                exportCollection.Collection = exportMenuItems;
                cc.Add(exportCollection);

                this.ContextMenu.ItemsSource = cc;
            }
            else
            {
                if (this.ContextMenu.HasItems)
                    this.ContextMenu.Items.Add(new Separator());

                this.ContextMenu.Items.Add(mi);
            }

            this.ContextMenu.Loaded -= ContextMenu_Loaded;
        }
    }
}
