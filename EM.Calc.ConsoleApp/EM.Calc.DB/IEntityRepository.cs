using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EM.Calc.DB
{
    public interface IEntityRepository<T> where T: class, IEntity
    {
        T Create();

        T Load(long id);

        void Update(T entity);

        void Delete(long id);

        IEnumerable<T> GetAll();
    }
}
