namespace AngularjsTreeView.DomainModel
{
    using System.Collections.Generic;

    public class TreeViewPageNode : TreeViewNode
    {
        public bool IsExpanded { get; set; }
        
        public IEnumerable<TreeViewPageNode> ChildNodes { get; set; }
    }
}