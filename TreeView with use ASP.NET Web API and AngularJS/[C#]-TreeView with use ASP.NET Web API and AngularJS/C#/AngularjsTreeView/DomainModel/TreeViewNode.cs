namespace AngularjsTreeView.DomainModel
{
    public class TreeViewNode
    {
        public int? Id { get; set; }

        public int? ParentId { get; set; }

        public string NodeName { get; set; }

        public bool IsSelected { get; set; }
    }
}