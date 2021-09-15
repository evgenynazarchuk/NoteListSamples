using NoteList.Domain.Models;

namespace NoteList.Dto.Queries
{
    public class NoteImageQuery : Identity
    {
        public string ImageData { get; set; }

        public int NoteItemId { get; set; }
    }
}
