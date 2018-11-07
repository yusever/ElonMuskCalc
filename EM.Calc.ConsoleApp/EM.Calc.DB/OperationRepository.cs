using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EM.Calc.DB
{
    public class OperationRepository : IEntityRepository<Operation>
    {
        string connectionString;

        public OperationRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Operation Create()
        {
            return new Operation();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operation> GetAll()
        {
            throw new NotImplementedException();
        }

        public Operation Load(long id)
        {
            var result = new Operation();

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                  $"SELECT Id, Name, Rating FROM Operation WHERE Id = {id};",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result.Id = reader.GetInt64(0);
                        result.Name = reader.GetString(1);
                        result.Rating = reader.GetInt32(2);
                    }
                }
                else
                {
                    result = null;
                }
                reader.Close();
            }
            return result;
        }

        public void Update(Operation entity)
        {
            throw new NotImplementedException();
        }
    }
}
