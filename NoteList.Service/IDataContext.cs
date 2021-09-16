using NoteList.Domain.Models;

namespace NoteList.Service
{
    public interface IDataContext
    {
        public IRepository<TEntity> GetEntityRepository<TEntity>()
            where TEntity : Identity, new();
    }
}
