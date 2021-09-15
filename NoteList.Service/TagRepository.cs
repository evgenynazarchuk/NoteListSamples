using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Services
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(
            DataWriteContext dbWrite,
            DataReadContext dbRead
            )
            : base(dbWrite, dbRead)
        { }

        public async Task<List<NoteItem>> GetNotes(int id)
        {
            var tag = dbRead.Set<Tag>().Include(x => x.NoteItems);
            var result = await tag.SingleAsync(x => x.Id == id);
            return result.NoteItems;
        }
    }
}
