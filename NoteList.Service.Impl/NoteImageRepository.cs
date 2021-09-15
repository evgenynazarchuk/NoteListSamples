using NoteList.Domain.Models;

namespace NoteList.Services.Impl
{
    public class NoteImageRepository : Repository<NoteImage>, INoteImageRepository
    {
        public NoteImageRepository(
            DataWriteContext dbWrite,
            DataReadContext dbRead
            )
            : base(dbWrite, dbRead)
        { }
    }
}
