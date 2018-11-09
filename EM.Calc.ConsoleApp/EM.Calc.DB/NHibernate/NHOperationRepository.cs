using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace EM.Calc.DB
{
    public class NHOperationRepository : IEntityRepository<Operation>
    {
        public Operation Create()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Operation> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Operation Load(long id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            var operation = session.CreateCriteria<Operation>()
                .Add(Restrictions.Eq("Id", id))
                .UniqueResult<Operation>();

            NHibernateHelper.CloseSession();

            return operation;
        }

        public void Save(Operation entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
