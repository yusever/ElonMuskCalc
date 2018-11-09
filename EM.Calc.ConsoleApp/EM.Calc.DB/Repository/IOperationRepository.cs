namespace EM.Calc.DB
{
    public interface IOperationRepository : IEntityRepository<Operation>
    {
        Operation LoadByName(string connectionString);
    }
}
