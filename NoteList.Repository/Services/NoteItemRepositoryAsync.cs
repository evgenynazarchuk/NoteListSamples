using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using NoteList.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Repository.Services
{
    public class NoteItemRepositoryAsync : RepositoryAsync<NoteItem>
    {

        public NoteItemRepositoryAsync(AppDataContext data)
            : base(data)
        { }

        public async Task<List<Tag>> GetTags(int id)
        {
            var noteItemWithTags = Entities.Include(x => x.Tags);
            var noteItem = await noteItemWithTags.FirstOrDefaultAsync(x => x.Id == id);
            return noteItem.Tags;
        }
    }
}
