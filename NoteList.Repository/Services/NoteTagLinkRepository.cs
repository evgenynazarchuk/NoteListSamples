using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Threading.Tasks;

namespace NoteList.Repository.Services
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
