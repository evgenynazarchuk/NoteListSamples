using NoteList.Domain.Models;

namespace NoteList.Domain.Commands
{
    public class NoteImageCommand : Identity
    {
        public string ImageData { get; set; }

        public int NoteItemId { get; set; }
    }
}
