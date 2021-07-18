using NoteList.Domain.Models;

namespace NoteList.Domain.Commands
{
    public class NoteImageCommand : Identity
    {
        public byte[] ImageData { get; set; }

        public int NoteItemId { get; set; }
    }
}
