using System.Data.SqlClient;
using System.Linq;

namespace EM.Calc.DB
{
    public class OperationRepository : BaseRepository<Operation>, IOperationRepository
    {

        public OperationRepository(string connectionString) : base(connectionString)
        {
            TableName = "Operation";
        }

        public Operation LoadByName(string name)
        {
            var result = Create();

            var fields = string.Join(",", typeProperties.Select(p => p.Name));

            using (var connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    $"SELECT {fields} FROM {TableName} WHERE Name = N'{name}';",
                    connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            var column = reader.GetName(i);

                            var prop = typeProperties.FirstOrDefault(p => p.Name == column);

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
    }
}