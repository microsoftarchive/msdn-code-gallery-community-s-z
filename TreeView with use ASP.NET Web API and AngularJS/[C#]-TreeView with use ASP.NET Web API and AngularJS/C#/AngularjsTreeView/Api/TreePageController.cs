namespace AngularjsTreeView.Api
{
    using DataAccess;
    using DomainModel;
    using System.Collections.Generic;
    using System.Web.Http;

    public class TreePageController : ApiController
    {
        private readonly TreeViewDataService treeViewDataService =
            new TreeViewDataService(new TreeViewDataRepository());

        public TreePageItem Get()
        {
            return treeViewDataService.GetTreePageItem();
        }

        [HttpPost]
        public TreeDataMessage Update(IEnumerable<TreeViewPageNode> treeViewPageNodes)
        {
            return treeViewDataService.Update(treeViewPageNodes);
        }
    }
}
