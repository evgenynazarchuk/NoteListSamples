using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using NoteList.Repository.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.Repository.Services
{
    public class TagRepositoryAsync : RepositoryAsync<Tag>
    {

        public TagRepositoryAsync(AppDataContext data)
            : base(data)
        { }

        public async Task<List<NoteItem>> GetNotes(int tagId)
        {
            var tagWithNotes = Entities.Include(x => x.NoteItems);
            var tag = await tagWithNotes.FirstOrDefaultAsync(x => x.Id == tagId);
            return tag.NoteItems;
        }
    }
}
