using NoteList.Domain.Models;

namespace NoteList.Dto.Queries
{
    public class TagQuery : Identity
    {
        public string Name { get; set; }
    }
}
