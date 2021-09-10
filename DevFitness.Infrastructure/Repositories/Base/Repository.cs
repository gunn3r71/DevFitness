using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevFitness.Core.Entities.Base;
using DevFitness.Core.Interfaces.Repositories.Base;
using DevFitness.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DevFitness.Infrastructure.Repositories.Base
{
    public abstract class Repository<T> : IRepository<T> where T : Entity

    {
        protected readonly DevFitnessDbContext Context;
        protected DbSet<T> Entity = null;

        protected Repository(DevFitnessDbContext context)
        {
            Context = context;
            Entity = Context.Set<T>();
        }


        public async Task Add(T entity)
        {
            try
            {
                await Entity.AddAsync(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public Task Update(T entity)
        {
            try
            {
                Entity.Update(entity);
                return Task.CompletedTask;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var entity = await GetById(id);

                Entity.Remove(entity);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<IEnumerable<T>> Get()
        {
            try
            {
                return await Entity.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<T> GetById(int id)
        {
            try
            {
                return await Entity.FindAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}