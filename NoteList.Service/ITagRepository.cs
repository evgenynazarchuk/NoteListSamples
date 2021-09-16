using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Service
{
    public interface ITagRepository : IRepository<Tag>
    {
        public Task<List<NoteItem>> GetNotes(int id);
    }
}
