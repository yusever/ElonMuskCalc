using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace EM.Calc.DB
{
    public class NHOperationResultRepository : IEntityRepository<OperationResult>
    {
        public OperationResult Create()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<OperationResult> GetAll()
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            var list = session.CreateCriteria<OperationResult>()
                .List<OperationResult>();

            NHibernateHelper.CloseSession();

            return list;
        }

        public OperationResult Load(long id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            var entity = session.Load<OperationResult>(id);

            NHibernateHelper.CloseSession();

            return entity;
        }

        public void Save(OperationResult entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
