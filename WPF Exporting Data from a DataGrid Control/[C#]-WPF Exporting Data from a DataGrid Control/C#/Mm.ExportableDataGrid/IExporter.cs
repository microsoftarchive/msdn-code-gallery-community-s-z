namespace Mm.ExportableDataGrid
{
    public interface IExporter
    {
        void AddColumn(string value);
        void AddLineBreak();
        string Export(string exportPath);
    }
}
