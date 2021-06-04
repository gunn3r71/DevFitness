using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Core.Entities
{
    public abstract class Base
    {
        protected Base()
        {
            this.CreatedAt = DateTime.Now;
            this.Active = true;
        }

        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }


        public void Desactivate()
        {
            this.Active = false;
        }
    }
}
