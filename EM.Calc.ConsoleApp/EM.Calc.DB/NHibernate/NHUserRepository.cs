using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;

namespace EM.Calc.DB
{
    public class NHUserRepository : IEntityRepository<User>
    {
        public User Create()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public User Load(long id)
        {
            ISession session = NHibernateHelper.GetCurrentSession();

            var user = session.CreateCriteria<User>()
                .Add(Restrictions.Eq("Id", id))
                .UniqueResult<User>();

            NHibernateHelper.CloseSession();

            return user;
        }

        public void Save(User entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
