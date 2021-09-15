using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteList.Services;
using System.Linq;

namespace NoteList.Services.Impl
{
    public class NoteItemRepository : Repository<NoteItem>
    {
        public NoteItemRepository(IServiceCollection services)
            : base(services)
        { }

        public async Task<List<Tag>> GetTags(int id)
        {
            var database = services.BuildServiceProvider().GetRequiredService<DataReadContext>();
            var noteItem = database.Set<NoteItem>().Include(x => x.Tags);
            var result = await noteItem.SingleAsync(x => x.Id == id);
            return result.Tags;
        }
    }
}
