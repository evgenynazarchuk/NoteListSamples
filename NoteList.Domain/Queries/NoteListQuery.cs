using NoteList.Domain.Models;

namespace NoteList.Domain.Queries
{
    public class NoteListQuery : Identity
    {
        public string Name { get; set; }
    }
}
