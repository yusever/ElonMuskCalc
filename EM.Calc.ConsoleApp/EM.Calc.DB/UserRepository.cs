using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.DB
{
    public class UserRepository : BaseRepository<User>
    {
        string connectionString;

        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public override string TableName { get => "Users"; }

        public override string Fields { get => "Login, Password, Roles, Email, BirthDay, Status, Company, Sex"; }
    }
}
