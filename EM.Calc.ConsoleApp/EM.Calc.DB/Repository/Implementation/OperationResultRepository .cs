using System.Collections.Generic;
using System.Linq;

namespace EM.Calc.DB
{
    public class OperationResultRepository : BaseRepository<OperationResult>, IOperationResultRepository
    {

        public OperationResultRepository(string connectionString) : base(connectionString)
        {
            TableName = "OperationResult";
        }

        public IEnumerable<OperationResult> LoadByOperation(Operation operation)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<OperationResult> LoadByUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}