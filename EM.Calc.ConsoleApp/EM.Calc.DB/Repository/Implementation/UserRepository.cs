﻿namespace EM.Calc.DB
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
            TableName = "Users";
        }

        public void Block(long id)
        {
            throw new System.NotImplementedException();
        }

        public User LoadByName(string name)
        {
            throw new System.NotImplementedException();
        }
    }
}