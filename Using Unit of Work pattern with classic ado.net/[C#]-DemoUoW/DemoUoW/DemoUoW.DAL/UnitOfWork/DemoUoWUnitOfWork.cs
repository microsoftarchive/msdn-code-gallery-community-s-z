using System;
using System.Data;

namespace DemoUoW.DAL.UnitOfWork
{
    public class DemoUoWUnitOfWork : IUnitOfWork 
    {
        public bool _hasConnection { get; set; }

        public IDbTransaction _transaction { get; set; }

        public IDbConnection _connection { get; set; }

        public DemoUoWUnitOfWork(IDbConnection connection, bool hasConnection)
        {
            _connection = connection;
            _hasConnection = hasConnection;
            _transaction = connection.BeginTransaction();
        }

        // Cria nosso objeto de commando.
        public IDbCommand CreateCommand()
        {
            var command = _connection.CreateCommand();
            command.Transaction = _transaction;
            return command;
        }

        // Salva as nossas alterações, verificando se a transaction é nula.
        // Após comitar a transação, seta null para evitar problemas de concorrência. 
        public void SaveChanges()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException(
                    "A transação já foi comitada");
            }

            _transaction.Commit();
            _transaction = null;
        }

        // Fecha nossa conexão, e caso alguma transação esteja em uso faz um Rollback. 
        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
                _transaction = null;
            }

            if (_connection != null && _hasConnection)
            {
                _connection.Close();
                _connection = null;
            }
        }
    }
}
