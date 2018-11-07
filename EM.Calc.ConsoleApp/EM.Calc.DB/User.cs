using System;

namespace EM.Calc.DB
{
    public class User : IEntity
    {
        public long Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Roles { get; set; }

        public string Email { get; set; }

        public DateTime? BirthDay { get; set; }

        public long Status { get; set; }

        public string Company { get; set; }

        public bool Sex { get; set; }
    }
}
