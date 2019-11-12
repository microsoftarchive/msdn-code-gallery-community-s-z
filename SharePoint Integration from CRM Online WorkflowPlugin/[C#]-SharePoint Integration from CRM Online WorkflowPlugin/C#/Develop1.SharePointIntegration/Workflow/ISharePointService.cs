using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Develop1.Workflow.SharePoint
{
    public interface ISharePointService
    {
        void CreateFolder(string siteUrl, string relativePath);
       
    }
}
