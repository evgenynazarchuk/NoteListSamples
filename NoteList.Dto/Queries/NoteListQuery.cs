using NoteList.Domain.Models;

namespace NoteList.Dto.Queries
{
    public class NoteListQuery : Identity
    {
        public string Name { get; set; }
    }
}
