namespace EM.Calc.DB
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
            TableName = "Users";
        }
    }
}
