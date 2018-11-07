using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace EM.Calc.DB
{
    public class OperationResultRepository : BaseRepository<OperationResult>
    {
        string connectionString;

        public OperationResultRepository(string connectionString) : base(connectionString)
        {
        }

        public override string TableName { get => "OperationResult"; }

        public override string Fields { get => "OperationId, UserId, Args, Result, CreationDate, Status, ExecTime"; }
    }
}
