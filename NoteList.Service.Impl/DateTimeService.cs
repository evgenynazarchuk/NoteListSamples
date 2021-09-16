using System;

namespace NoteList.Service.Impl
{
    public class DateTimeService : IDateTimeService
    {
        public virtual DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
