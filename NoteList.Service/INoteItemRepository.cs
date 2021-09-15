using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Services
{
    public interface INoteItemRepository : IRepository<NoteItem>
    {
        public Task<List<Tag>> GetTags(int id);
    }
}
