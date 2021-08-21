using System;
using System.Collections.Generic;
using DevFitness.Core.Entities.Base;

namespace DevFitness.Core.Entities
{
    public class User : Entity
    {
        protected User()
        {
        }

        public User(string fullName, decimal height, decimal weight, DateTime birthDate) : base()
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
            BirthDate = birthDate;
            Active = true;
        }

        public string FullName { get; private set; }
        public decimal Height { get; private set; }
        public decimal Weight { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }

        public IEnumerable<Meal> Meals { get; private set; }
    }
}
