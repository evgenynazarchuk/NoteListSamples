using System;

namespace NoteList.Service
{
    public interface IDateTimeService
    {
        DateTime GetUtcNow();
    }
}
