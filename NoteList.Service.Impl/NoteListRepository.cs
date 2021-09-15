using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteList.Services.Impl;
using NoteList.Services;
using Microsoft.Extensions.DependencyInjection;

namespace NoteList.Services.Impl
{
    public class NoteListRepository : Repository<NoteList.Domain.Models.NoteList>
    {
        public NoteListRepository(IServiceCollection services)
            : base(services)
        { }

        public async Task<List<NoteItem>> GetNotes(int id)
        {
            var database = services.BuildServiceProvider().GetRequiredService<DataReadContext>();
            var list = database.Set<NoteList.Domain.Models.NoteList>().Include(x => x.NoteItem);
            var result = await list.SingleAsync(x => x.Id == id);
            return result.NoteItem;
        }
    }
}
