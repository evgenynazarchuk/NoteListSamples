using NoteList.Domain.Models;

namespace NoteList.Domain.Commands
{
    public class NoteListCommand : Identity
    {
        public string Name { get; set; }
    }
}
