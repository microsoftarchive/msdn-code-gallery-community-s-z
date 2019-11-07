using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DemoUoW.DAL.UnitOfWork;
using DemoUoW.Model;

namespace DemoUoW.DAL.Repositories
{
    public class PeopleRepository
    {
        private DemoUoWUnitOfWork _unitOfWork;

        public PeopleRepository(IUnitOfWork uow)
        {
            if (uow == null)
                throw new ArgumentNullException("uow");

            _unitOfWork = uow as DemoUoWUnitOfWork;

            if (_unitOfWork == null)
            {
                throw new NotSupportedException("UnitOfWork Factory está nulo.");
            }
        }

        public People GetPeopleById(long id)
        {
      
            using (var cmd = _unitOfWork.CreateCommand())
            {
                cmd.CommandText = "SELECT Name, Age, Address FROM People WHERE Id = @id";

                SqlParameter parameter = new SqlParameter()
                {
                    Value = id,
                    ParameterName = "@id"
                };

                
                cmd.Parameters.Add(parameter);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        People people = new People();

                        people.Id = id;
                        people.Name = reader["Name"].ToString();
                        people.Age = Convert.ToInt32(reader["Age"]);
                        people.Address = reader["Address"].ToString();

                        return people;
                    }
                    return null;
                }
            }
        }

        public bool DeletePeople(long id)
        {
            // Inicia nosso objeto de comando. 
            using (var cmd = _unitOfWork.CreateCommand())
            {
                cmd.CommandText = "DELETE PEOPLE WHERE id = @Id";

                // Adiciona um parâmetetro via IDbCommand, para evitar SqlInjection
                SqlParameter parameter = new SqlParameter() { Value = id, ParameterName = "@Id" };

                cmd.Parameters.Add(parameter);

                bool success = cmd.ExecuteNonQuery() > 0;

                //Comita nossa transação.
                _unitOfWork.SaveChanges();

                return success;
            }
        }

        public bool CreatePeople(People people)
        {
            using (var cmd = _unitOfWork.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO PEOPLE(Name, Age, Address) VALUES (@Name, @Age, @Address)";

                SqlParameter[] parameters = new SqlParameter[3];

                parameters[0] = new SqlParameter() { Value = people.Name, ParameterName = "@Name" };

                parameters[1] = new SqlParameter() {Value = people.Age, ParameterName = "@Age"};

                parameters[2] = new SqlParameter() { Value = people.Address, ParameterName= "@Address"};

                cmd.Parameters.Add(parameters[0]);
                cmd.Parameters.Add(parameters[1]);
                cmd.Parameters.Add(parameters[2]);


             bool success = cmd.ExecuteNonQuery() > 0;
                
                _unitOfWork.SaveChanges();

                return success;
            }
        }

        public bool UpdatePeople(People people)
        {
            using (var cmd = _unitOfWork.CreateCommand())
            {
                cmd.CommandText = "UPDATE PEOPLE SET Name = @Name, Age = @Age, Address = @Address WHERE id = @Id";

                SqlParameter[] parameters = new SqlParameter[4];

                parameters[0] = new SqlParameter() { Value = people.Name, ParameterName = "@Name" };

                parameters[1] = new SqlParameter() { Value = people.Age, ParameterName = "@Age" };

                parameters[2] = new SqlParameter() { Value = people.Address, ParameterName = "@Address" };

                parameters[3] = new SqlParameter() { Value = people.Id, ParameterName = "@Id" };

                cmd.Parameters.Add(parameters[0]);
                cmd.Parameters.Add(parameters[1]);
                cmd.Parameters.Add(parameters[2]);
                cmd.Parameters.Add(parameters[3]);

                bool success = cmd.ExecuteNonQuery() > 0;

                _unitOfWork.SaveChanges();

                return success;
            }
        }

        public IEnumerable<People> ShowPeoples()
        {
            using (var cmd = _unitOfWork.CreateCommand())
            {
                cmd.CommandText = "SELECT Id, Name, Age, Address FROM People";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        People people = new People();

                        people.Id = Convert.ToInt64(reader["Id"]);
                        people.Name = reader["Name"].ToString();
                        people.Age = Convert.ToInt16(reader["Age"]);
                        people.Address = reader["Address"].ToString();

                        yield return people;
                    }
                }
            }
        }
    }

}
