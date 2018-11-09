namespace EM.Calc.DB
{
    public class OperationResultRepository : BaseRepository<OperationResult>
    {

        public OperationResultRepository(string connectionString) : base(connectionString)
        {
            TableName = "OperationResult";
        }
    }
}
