using System;

namespace NoteList.Domain.Interfaces
{
    public interface ITimeTracker
    {
        DateTime CreatedDate { get; set; }

        DateTime ModifiedDate { get; set; }
    }
}
