using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Service
{
    public interface INoteListRepository : IRepository<Domain.Models.NoteList>
    {
        public Task<List<NoteItem>> GetNotes(int id);
    }
}
