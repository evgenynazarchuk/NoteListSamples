using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Services
{
    public interface ITagRepository : IRepository<Tag>
    {
        public Task<List<NoteItem>> GetNotes(int id);
    }
}
