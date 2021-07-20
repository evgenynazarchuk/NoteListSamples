using NoteList.Domain.Models;

namespace NoteList.Domain.Commands
{
    public class NoteItemCommand : Identity
    {
        public string NoteText { get; set; }

        public int NoteListId { get; set; }
    }
}
