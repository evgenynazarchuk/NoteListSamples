using Microsoft.EntityFrameworkCore;
using NoteList.Domain.Models;
using System.Threading.Tasks;

namespace NoteList.Services
{
    public interface INoteTagLinkRepository
    {
        public Task<NoteTagLink> CreateLinkAsync(NoteTagLink link);

        public Task<NoteTagLink> RemoveLinkAsync(NoteTagLink link);
    }
}
