using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Threading.Tasks;
using NoteList.Services;
using Microsoft.Extensions.DependencyInjection;

namespace NoteList.Services
{
    public class NoteTagLinkRepository
    {
        protected readonly DataWriteContext dbWrite;

        protected readonly DbSet<NoteTagLink> Entity;

        public NoteTagLinkRepository(DataWriteContext dataContext)
        {
            this.dbWrite = dataContext;
            this.Entity = this.dbWrite.Set<NoteTagLink>();
        }

        public async Task<NoteTagLink> CreateLinkAsync(NoteTagLink link)
        {
            await Entity.AddAsync(link);
            await this.dbWrite.SaveChangesAsync();
            return link;
        }

        public async Task<NoteTagLink> RemoveLinkAsync(NoteTagLink link)
        {
            this.Entity.Remove(link);
            await this.dbWrite.SaveChangesAsync();
            return link;
        }
    }
}
