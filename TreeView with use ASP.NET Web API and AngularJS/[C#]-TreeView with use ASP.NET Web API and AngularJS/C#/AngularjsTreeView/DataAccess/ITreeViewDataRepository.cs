namespace AngularjsTreeView.DataAccess
{
    using DomainModel;
    using System.Collections.Generic;

    public interface ITreeViewDataRepository
    {
        IList<TreeViewNode> GetAllTreeViewNodes();

        void Update(IList<TreeViewNode> treeViewNodes);
    }
}