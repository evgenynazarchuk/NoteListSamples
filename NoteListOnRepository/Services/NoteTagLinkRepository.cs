using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteListOnRepository.Services
{
    public class NoteTagLinkRepository
    {
        protected readonly AppDataContext Data;
        protected readonly DbSet<NoteTagLink> Entities;

        public NoteTagLinkRepository(AppDataContext data)
        {
            Data = data;
            Entities = Data.Set<NoteTagLink>();
        }

        public async Task<List<NoteItem>> GetNotesByTagAsync(int id)
        {
            var notes = await Entities
                .AsNoTracking()
                .Where(e => e.TagId == id)
                .Select(e => e.NoteItem)
                .ToListAsync();
            return notes;
        }

        public async Task<List<Tag>> GetTagsByNoteAsync(int id)
        {
            var tags = await Entities
                .AsNoTracking()
                .Where(e => e.NoteItemId == id)
                .Select(e => e.Tag)
                .ToListAsync();
            return tags;
        }

        public async Task<List<NoteTagLink>> GetLinksAsync()
        {
            var links = await Entities.AsNoTracking().ToListAsync();
            return links;
        }

        public async Task<NoteTagLink> CreateLinkAsync(NoteTagLink link)
        {
            await Entities.AddAsync(link);
            await Data.SaveChangesAsync();
            return link;
        }

        public async Task<NoteTagLink> RemoveLinkAsync(NoteTagLink link)
        {
            var removeLink = Entities.Remove(link).Entity;
            await Data.SaveChangesAsync();
            return removeLink;
        }
    }
}
