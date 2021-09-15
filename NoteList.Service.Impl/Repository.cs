using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteList.Services;
using Microsoft.Extensions.DependencyInjection;

namespace NoteList.Services.Impl
{
    public class Repository<Entity> : IRepository<Entity>
        where Entity : Identity, new()
    {
        protected readonly IServiceCollection services;

        public Repository(IServiceCollection services)
        {
            this.services = services;
        }

        public async Task<List<Entity>> GetAsync()
        {
            var database = services.BuildServiceProvider().GetRequiredService<DataReadContext>();
            var result = await database.Set<Entity>().ToListAsync();
            return result;
        }

        public async Task<Entity> GetAsync(int id)
        {
            var database = services.BuildServiceProvider().GetRequiredService<DataReadContext>();
            var result = await database.Set<Entity>().FindAsync(id);
            return result;
        }

        public async Task<Entity> CreateAsync(Entity entity)
        {
            var database = services.BuildServiceProvider().GetRequiredService<DataWriteContext>();
            await database.Set<Entity>().AddAsync(entity);
            await database.SaveChangesAsync();
            return entity;
        }

        public async Task<Entity> DeleteAsync(int id)
        {
            var database = services.BuildServiceProvider().GetRequiredService<DataWriteContext>();
            var entity = await this.GetAsync(id);
            database.Set<Entity>().Remove(entity);
            await database.SaveChangesAsync();
            return entity;
        }

        public async Task<Entity> PutAsync(Entity entity)
        {
            var database = services.BuildServiceProvider().GetRequiredService<DataWriteContext>();
            database.Set<Entity>().Update(entity);
            await database.SaveChangesAsync();
            return entity;
        }
    }
}
