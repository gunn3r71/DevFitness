using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Core.Entities
{
    public class User : Base
    {
        public User(string fullName, decimal height, decimal weight, DateTime birthDate) : base()
        {
            FullName = fullName;
            Height = height;
            Weight = weight;
            BirthDate = birthDate;
        }

        public string FullName { get; private set; }
        public decimal Height { get; private set; }
        public decimal Weight { get; private set; }
        public DateTime BirthDate { get; private set; }

        public IEnumerable<Meal> Meals { get; private set; }

        public void Update(decimal height, decimal weight)
        {
            if (height > 0 && weight > 0)
            {
                this.Height = height;
                this.Weight = weight;
            }
        }
    }
}
