using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Service
{
    public interface INoteItemRepository : IRepository<NoteItem>
    {
        public Task<List<Tag>> GetTags(int id);
    }
}
