using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Services
{
    public interface IRepository<Entity>
        where Entity : Identity, new()
    {
        Task<List<Entity>> GetAsync();
        Task<Entity> GetAsync(int id);
        Task<Entity> PutAsync(Entity entity);
        Task<Entity> DeleteAsync(int id);
        Task<Entity> CreateAsync(Entity entity);
    }
}
