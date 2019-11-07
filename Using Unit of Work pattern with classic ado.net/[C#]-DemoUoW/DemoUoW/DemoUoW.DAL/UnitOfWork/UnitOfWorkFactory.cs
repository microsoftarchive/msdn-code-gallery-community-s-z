using System.Configuration;
using System.Data.SqlClient;

namespace DemoUoW.DAL.UnitOfWork
{
    public class UnitOfWorkFactory
    {
        public static IUnitOfWork Create()
        {
            string connString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            var connection = new SqlConnection(connString);

            // Inicia a conexão
            connection.Open();

            // Retorna uma nova unidade de trabalho
            return new DemoUoWUnitOfWork(connection, true);
        }
    }
}
