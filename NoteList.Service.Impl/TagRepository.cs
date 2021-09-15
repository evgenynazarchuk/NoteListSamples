using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteList.Services.Impl;
using NoteList.Services;
using Microsoft.Extensions.DependencyInjection;

namespace NoteList.Services.Impl
{
    public class TagRepository : Repository<Tag>
    {
        public TagRepository(IServiceCollection services)
            : base(services)
        { }

        public async Task<List<NoteItem>> GetNotes(int id)
        {
            var database = services.BuildServiceProvider().GetRequiredService<DataReadContext>();
            var tag = database.Set<Tag>().Include(x => x.NoteItems);
            var result = await tag.SingleAsync(x => x.Id == id);
            return result.NoteItems;
        }
    }
}
