using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Service.Impl
{
    public class NoteListRepository : Repository<Domain.Models.NoteList>, INoteListRepository
    {
        public NoteListRepository(DataContext context, IDateTimeService dateTimeService)
            : base(context, dateTimeService)
        { }

        public async Task<List<NoteItem>> GetNotes(int id)
        {
            var noteLists = this.context.Set<Domain.Models.NoteList>().Include(x => x.NoteItem);
            var noteList = await noteLists.SingleAsync(x => x.Id == id);

            return noteList.NoteItem;
        }
    }
}
