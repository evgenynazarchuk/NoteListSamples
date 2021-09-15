using NoteList.Domain.Models;

namespace NoteList.Dto.Commands
{
    public class TagCommand : Identity
    {
        public string Name { get; set; }
    }
}
