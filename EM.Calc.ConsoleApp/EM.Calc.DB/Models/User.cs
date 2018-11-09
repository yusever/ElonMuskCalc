using System;

namespace EM.Calc.DB
{
    public class User : IEntity
    {
        public virtual long Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        public virtual Role Role { get; set; }

        public virtual string Email { get; set; }

        public virtual DateTime? BirthDay { get; set; }

        public virtual UserStatus Status { get; set; }

        public virtual string Company { get; set; }

        public virtual bool Sex { get; set; }
    }

    public enum UserStatus
    {
        ACTIVE,
        BLOCKED,
        DELETED
    }
}
