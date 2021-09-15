using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Services
{
    public class NoteItemRepository : Repository<NoteItem>
    {
        public NoteItemRepository(
            DataWriteContext dbWrite,
            DataReadContext dbRead
            )
            : base(dbWrite, dbRead)
        { }

        public async Task<List<Tag>> GetTags(int id)
        {
            var noteItems = dbRead.Set<NoteItem>().Include(x => x.Tags);
            var note = await noteItems.SingleAsync(x => x.Id == id);
            return note.Tags;
        }
    }
}
