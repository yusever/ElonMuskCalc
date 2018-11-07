using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EM.Calc.DB
{
    public class BaseRepository<T> : IEntityRepository<T> where T : class, IEntity
    {
        string connectionString;

        public BaseRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public T Create()
        {
            return Activator.CreateInstance<T>();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public virtual string TableName { get; set; }

        public virtual string Fields { get; set; }

        public T Load(long id)
        {
            var result = Create();

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                  $"SELECT Id, {Fields} FROM {TableName} WHERE Id = {id};",
                  connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var type = typeof(T);
                        var props = type.GetProperties();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var column = reader.GetName(i);
                            var prop = props.FirstOrDefault(p => p.Name == column);
                            if (prop != null)
                            {
                                prop.SetValue(result, reader[i]);
                            }
                        }
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

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
