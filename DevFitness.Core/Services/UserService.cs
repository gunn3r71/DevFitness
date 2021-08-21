using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevFitness.Core.Entities;
using DevFitness.Core.Interfaces.Services;

namespace DevFitness.Core.Services
{
    public class UserService : IUserService
    {
        public async Task Add(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task Update(User entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DisableUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task EnableUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}