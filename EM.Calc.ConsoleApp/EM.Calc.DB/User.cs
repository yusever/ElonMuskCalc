using System;

namespace EM.Calc.DB
{
    public class User : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Login { get; set; }

        public virtual DateTime? BirthDay { get; set; }

        public virtual bool Sex { get; set; }
    }
}
