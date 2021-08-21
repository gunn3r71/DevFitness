using System;

namespace DevFitness.Core.Entities.Base
{
    public abstract class Entity
    {
        protected Entity()
        {
            this.CreatedAt = DateTime.UtcNow.AddHours(-3);
            this.UpdatedAt = DateTime.UtcNow.AddHours(-3);
        }

        public int Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
