using NoteList.Domain.Models;

namespace NoteList.Services
{
    public class NoteImageRepository : Repository<NoteImage>
    {
        public NoteImageRepository(
            DataWriteContext dbWrite,
            DataReadContext dbRead
            )
            : base(dbWrite, dbRead)
        { }
    }
}
