using NoteList.Domain.Models;

namespace NoteList.Dto.Commands
{
    public class NoteListCommand : Identity
    {
        public string Name { get; set; }
    }
}
