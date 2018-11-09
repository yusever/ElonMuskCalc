using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace EM.Calc.DB
{
    public class NHBaseRepository<T> : IEntityRepository<T> where T : class, IEntity
    {
        public T Create()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public T Load(long id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            var result = session.CreateCriteria<T>()
                .Add(Restrictions.Eq("Id", id))
                .UniqueResult<T>();

            NHibernateHelper.CloseSession();
            return result;
        }

        public void Save(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
