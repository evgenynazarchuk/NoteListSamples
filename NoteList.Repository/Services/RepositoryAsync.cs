using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using NoteList.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Repository.Services
{
    public class RepositoryAsync<Entity> : IRepositoryAsync<Entity>
        where Entity : Identity, new()
    {
        protected readonly AppDataContext Data;
        protected readonly DbSet<Entity> Entities;

        public RepositoryAsync(AppDataContext data)
        {
            Data = data;
            Entities = Data.Set<Entity>();
        }

        public async Task<Entity> CreateAsync(Entity entity)
        {
            await Entities.AddAsync(entity);
            await Data.SaveChangesAsync();
            return entity;
        }

        public async Task<Entity> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);
            var removeEntity = Entities.Remove(entity).Entity;
            await Data.SaveChangesAsync();
            return removeEntity;
        }

        public async Task<List<Entity>> GetAsync()
        {
            var entities = await Entities.AsNoTracking().ToListAsync();
            return entities;
        }

        public async Task<Entity> GetAsync(int id)
        {
            var entity = await Entities.AsNoTracking().SingleOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public async Task<Entity> PutAsync(Entity entity)
        {
            var update = Entities.Update(entity).Entity;
            await Data.SaveChangesAsync();
            return update;
        }
    }
}
