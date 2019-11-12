namespace Mm.ExportableDataGrid.Wpf
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAvailable { get; set; }
        public Category Category { get; set; }
    }
}
