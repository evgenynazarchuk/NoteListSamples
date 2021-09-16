using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Service.Impl
{
    public class NoteItemRepository : Repository<NoteItem>, INoteItemRepository
    {
        public NoteItemRepository(DataContext context, IDateTimeService dateTimeService)
            : base(context, dateTimeService)
        { }

        public async Task<List<Tag>> GetTags(int id)
        {
            var noteItems = this.context.Set<NoteItem>().Include(x => x.Tags);
            var note = await noteItems.SingleAsync(x => x.Id == id);
            return note.Tags;
        }
    }
}
