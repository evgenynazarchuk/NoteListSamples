using NoteList.Domain.Models;

namespace NoteList.Domain.Queries
{
    public class NoteImageQuery : Identity
    {
        public byte[] ImageData { get; set; }

        public int NoteItemId { get; set; }
    }
}
