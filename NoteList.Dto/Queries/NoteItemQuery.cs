using NoteList.Domain.Models;

namespace NoteList.Dto.Queries
{
    public class NoteItemQuery : Identity
    {
        public string NoteText { get; set; }

        public int NoteListId { get; set; }
    }
}
