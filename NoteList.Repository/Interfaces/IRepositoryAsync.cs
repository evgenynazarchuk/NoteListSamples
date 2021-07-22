using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Repository.Interfaces
{
    public interface IRepositoryAsync<Entity>
        where Entity : Identity, new()
    {
        Task<List<Entity>> GetAsync();
        Task<Entity> GetAsync(int id);
        Task<Entity> PutAsync(Entity entity);
        Task<Entity> DeleteAsync(int id);
        Task<Entity> CreateAsync(Entity entity);
    }
}
