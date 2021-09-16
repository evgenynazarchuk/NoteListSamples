using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Threading.Tasks;

namespace NoteList.Service.Impl
{
    public class NoteTagLinkRepository : INoteTagLinkRepository
    {
        protected readonly DataContext context;

        protected readonly DbSet<NoteTagLink> entity;

        protected readonly IDateTimeService dateTimeService;

        public NoteTagLinkRepository(DataContext context, IDateTimeService dateTimeService)
        {
            this.context = context;
            this.entity = this.context.Set<NoteTagLink>();
            this.dateTimeService = dateTimeService;
        }

        public async Task<NoteTagLink> CreateLinkAsync(NoteTagLink link)
        {
            link.CreatedDate = this.dateTimeService.GetUtcNow();
            link.ModifiedDate = this.dateTimeService.GetUtcNow();

            await entity.AddAsync(link);
            await this.context.SaveChangesAsync();

            return link;
        }

        public async Task<NoteTagLink> RemoveLinkAsync(NoteTagLink link)
        {
            link.ModifiedDate = this.dateTimeService.GetUtcNow();

            this.entity.Remove(link);
            await this.context.SaveChangesAsync();

            return link;
        }
    }
}
