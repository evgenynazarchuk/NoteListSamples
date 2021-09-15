using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteList.Services;
using Microsoft.Extensions.DependencyInjection;

namespace NoteList.Services
{
    public class NoteListRepository : Repository<Domain.Models.NoteList>
    {
        public NoteListRepository(
            DataWriteContext dbWrite,
            DataReadContext dbRead
            )
            : base(dbWrite, dbRead)
        { }

        public async Task<List<NoteItem>> GetNotes(int id)
        {
            var noteLists = dbRead.Set<Domain.Models.NoteList>().Include(x => x.NoteItem);
            var noteList = await noteLists.SingleAsync(x => x.Id == id);
            return noteList.NoteItem;
        }
    }
}
