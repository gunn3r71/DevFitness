using System;
using DevFitness.Core.Entities;
using DevFitness.Core.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevFitness.Infrastructure.Context;
using DevFitness.Infrastructure.Repositories.Base;

namespace DevFitness.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DevFitnessDbContext context) : base(context)
        {
        }
    }
}