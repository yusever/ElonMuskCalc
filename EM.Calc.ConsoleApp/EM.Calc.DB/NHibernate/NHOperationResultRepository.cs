using System.Collections.Generic;

namespace EM.Calc.DB
{
    public class NHOperationResultRepository : NHBaseRepository<OperationResult>, IOperationResultRepository
    {
        public IEnumerable<OperationResult> LoadByOperation(Operation operation)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var entities = session.QueryOver<OperationResult>()
                .And(o => o.Operation == operation)
                .List();

            NHibernateHelper.CloseSession();

            return entities;
        }

        public IEnumerable<OperationResult> LoadByUser(User user)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var entities = session.QueryOver<OperationResult>()
                .And(o => o.User == user)
                .List();

            NHibernateHelper.CloseSession();

            return entities;
        }
    }
}
