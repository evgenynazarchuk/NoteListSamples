using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteList.Services;
using Microsoft.Extensions.DependencyInjection;

namespace NoteList.Services
{
    public class Repository<Entity> : IRepository<Entity>
        where Entity : Identity, new()
    {
        protected readonly IServiceCollection services;

        protected readonly DataWriteContext dbWrite;

        protected readonly DataReadContext dbRead;

        public Repository(
            DataWriteContext dbWrite,
            DataReadContext dbRead
            )
        {
            this.dbWrite = dbWrite;
            this.dbRead = dbRead;
        }

        public async Task<List<Entity>> GetAsync()
        {
            var result = await dbRead.Set<Entity>().ToListAsync();
            return result;
        }

        public async Task<Entity> GetAsync(int id)
        {
            var result = await dbRead.Set<Entity>().FindAsync(id);
            return result;
        }

        public async Task<Entity> CreateAsync(Entity entity)
        {
            await dbWrite.Set<Entity>().AddAsync(entity);
            await dbWrite.SaveChangesAsync();
            return entity;
        }

        public async Task<Entity> DeleteAsync(int id)
        {
            var entity = await this.GetAsync(id);
            dbWrite.Set<Entity>().Remove(entity);
            await dbWrite.SaveChangesAsync();
            return entity;
        }

        public async Task<Entity> PutAsync(Entity entity)
        {
            dbWrite.Set<Entity>().Update(entity);
            await dbWrite.SaveChangesAsync();
            return entity;
        }
    }
}
