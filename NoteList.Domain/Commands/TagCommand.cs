using NoteList.Domain.Models;

namespace NoteList.Domain.Commands
{
    public class TagCommand : Identity
    {
        public string Name { get; set; }
    }
}
