using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Threading.Tasks;
using NoteList.Services;
using Microsoft.Extensions.DependencyInjection;

namespace NoteList.Services.Impl
{
    public class NoteTagLinkRepository
    {
        protected readonly DataWriteContext dataContext;

        protected readonly DbSet<NoteTagLink> Entity;

        public NoteTagLinkRepository(DataWriteContext dataContext)
        {
            this.dataContext = dataContext;
            this.Entity = this.dataContext.Set<NoteTagLink>();
        }

        public async Task<NoteTagLink> CreateLinkAsync(NoteTagLink link)
        {
            await Entity.AddAsync(link);
            await this.dataContext.SaveChangesAsync();
            return link;
        }

        public async Task<NoteTagLink> RemoveLinkAsync(NoteTagLink link)
        {
            this.Entity.Remove(link);
            await this.dataContext.SaveChangesAsync();
            return link;
        }
    }
}
