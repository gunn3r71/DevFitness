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

        public User(string fullName, double height, double weight, DateTime birthDate) : base()
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
            BirthDate = birthDate;
            Active = true;
        }

        public string FullName { get; private set; }
        public double Height { get; private set; }
        public double Weight { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }

        public IEnumerable<Meal> Meals { get; private set; }

        public void Disable()
        {
            Active = false;
        }

        public void Enable()
        {
            Active = true;
        }
    }
}
