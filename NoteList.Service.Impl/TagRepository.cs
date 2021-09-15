using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Services.Impl
{
    public class TagRepository : Repository<Tag>, ITagRepository
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
