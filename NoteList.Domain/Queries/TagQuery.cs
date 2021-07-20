using NoteList.Domain.Models;

namespace NoteList.Domain.Queries
{
    public class TagQuery : Identity
    {
        public string Name { get; set; }
    }
}
