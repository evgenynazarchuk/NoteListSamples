using NoteList.Domain.Models;

namespace NoteList.Service.Impl
{
    public class NoteImageRepository : Repository<NoteImage>, INoteImageRepository
    {
        public NoteImageRepository(DataContext context, IDateTimeService dateTimeService)
            : base(context, dateTimeService)
        { }
    }
}
