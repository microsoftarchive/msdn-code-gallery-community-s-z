namespace AngularjsTreeView.DataAccess
{
    using System.Configuration;

    public abstract class RepositoryBase
    {
        protected string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["AngularTreeView"].ConnectionString; }
        }
    }
}