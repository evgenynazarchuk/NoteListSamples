using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Interfaces;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Service.Impl
{
    public class Repository<Entity> : IRepository<Entity>
        where Entity : Identity, new()
    {
        protected readonly DataContext context;

        protected readonly IDateTimeService dateTimeService;

        public Repository(DataContext context, IDateTimeService dateTimeService)
        {
            this.context = context;
            this.dateTimeService = dateTimeService;
        }

        public async Task<List<Entity>> GetAsync()
        {
            var result = await this.context.Set<Entity>().ToListAsync();

            return result;
        }

        public async Task<Entity> GetAsync(int id)
        {
            var result = await this.context.Set<Entity>().FindAsync(id);

            return result;
        }

        public async Task<Entity> CreateAsync(Entity entity)
        {
            if (entity is ITimeTracker)
            {
                (entity as ITimeTracker).CreatedDate = this.dateTimeService.GetUtcNow();
                (entity as ITimeTracker).ModifiedDate = this.dateTimeService.GetUtcNow();
            }

            await this.context.Set<Entity>().AddAsync(entity);
            await this.context.SaveChangesAsync();

            return entity;
        }

        public async Task<Entity> DeleteAsync(int id)
        {
            var entity = await this.GetAsync(id);

            if (entity is ITimeTracker)
            {
                (entity as ITimeTracker).ModifiedDate = this.dateTimeService.GetUtcNow();
            }

            this.context.Set<Entity>().Remove(entity);
            await this.context.SaveChangesAsync();

            return entity;
        }

        public async Task<Entity> PutAsync(Entity entity)
        {
            if (entity is ITimeTracker)
            {
                (entity as ITimeTracker).ModifiedDate = this.dateTimeService.GetUtcNow();
            }

            this.context.Set<Entity>().Update(entity);
            await this.context.SaveChangesAsync();

            return entity;
        }
    }
}
