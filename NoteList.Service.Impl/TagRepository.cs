using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Service.Impl
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(DataContext context, IDateTimeService dateTimeService)
            : base(context, dateTimeService)
        { }

        public async Task<List<NoteItem>> GetNotes(int id)
        {
            var tag = this.context.Set<Tag>().Include(x => x.NoteItems);
            var result = await tag.SingleAsync(x => x.Id == id);

            return result.NoteItems;
        }
    }
}
