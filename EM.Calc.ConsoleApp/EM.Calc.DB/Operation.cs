namespace EM.Calc.DB
{
    public class Operation : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual int Rating { get; set; }
    }
}

