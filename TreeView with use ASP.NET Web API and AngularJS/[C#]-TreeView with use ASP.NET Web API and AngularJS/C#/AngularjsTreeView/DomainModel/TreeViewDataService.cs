namespace AngularjsTreeView.DomainModel
{
    using DataAccess;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    public class TreeViewDataService
    {
        private readonly ITreeViewDataRepository treeViewDataRepository;

        public TreeViewDataService(ITreeViewDataRepository treeViewDataRepository)
        {
            this.treeViewDataRepository = treeViewDataRepository;
        }

        public TreePageItem GetTreePageItem()
        {
            var treePageItem = new TreePageItem();

            var rootTreeNode = new TreeViewPageNode();
            FillPageTreeNode(rootTreeNode, treeViewDataRepository.GetAllTreeViewNodes());
            treePageItem.TreeViewPageNodes = rootTreeNode.ChildNodes;

            return treePageItem;
        }

        public TreeDataMessage Update(IEnumerable<TreeViewPageNode> treeViewPageNodes)
        {
            var message = new TreeDataMessage() { DataProcessedSuccessfully = true };

            var treeViewNodes = new List<TreeViewNode>();
            FillPageTreeDataForUpdate(treeViewPageNodes.ToList(), treeViewNodes);
            treeViewDataRepository.Update(treeViewNodes);

            return message;
        }

        private void FillPageTreeNode(TreeViewPageNode parentTreeNode, 
            IList<TreeViewNode> treeViewNodes)
        {
            int? parentId = null;

            if (parentTreeNode.Id > 0)
                parentId = parentTreeNode.Id;

            parentTreeNode.ChildNodes = treeViewNodes
                .Where(node => parentId == node.ParentId).Select(node =>
            {
                var pageTreeNode = new TreeViewPageNode()
                {
                    Id = node.Id,
                    ParentId = node.ParentId,
                    NodeName = node.NodeName,
                    IsExpanded = false,
                };

                return pageTreeNode;

            }).ToList();

            foreach (var treeNode in parentTreeNode.ChildNodes)
            {
                FillPageTreeNode(treeNode, treeViewNodes);
            }
        }

        private void FillPageTreeDataForUpdate(IList<TreeViewPageNode> treeViewPageNodes, 
            List<TreeViewNode> treeViewNodes)
        {
            foreach (var treeViewPageNode in treeViewPageNodes)
            {
                Trace.WriteLine(treeViewPageNode.Id);
                if (treeViewPageNode.ChildNodes != null && treeViewPageNode.ChildNodes.Any())
                {
                    FillPageTreeDataForUpdate(treeViewPageNode.ChildNodes.ToList(), treeViewNodes);
                }

                treeViewNodes.Add(treeViewPageNode);
            }
        }
    }
}