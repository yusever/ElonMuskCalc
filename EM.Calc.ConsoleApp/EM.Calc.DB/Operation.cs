using System;

namespace EM.Calc.DB
{
    public class Operation : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public int Rating { get; set; }
    }
}

