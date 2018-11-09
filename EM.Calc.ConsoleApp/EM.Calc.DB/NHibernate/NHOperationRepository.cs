namespace EM.Calc.DB
{
    public class NHOperationRepository : NHBaseRepository<Operation>, IOperationRepository
    {
        public Operation LoadByName(string name)
        {
            var session = NHibernateHelper.GetCurrentSession();

            var entity = session.QueryOver<Operation>()
                .And(o => o.Name == name)
                .SingleOrDefault();

            NHibernateHelper.CloseSession();

            return entity;
        }
    }
}
