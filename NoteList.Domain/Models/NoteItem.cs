using System.Collections.Generic;

namespace NoteList.Domain.Models
{
    public class NoteItem : Identity
    {
        public string NoteText { get; set; }

        public int NoteImageId { get; set; }

        public NoteImage NoteImage { get; set; }

        public List<Tag> Tags { get; set; }

        public List<NoteTagLink> TagLinks { get; set; }

        public int NoteListId { get; set; }

        public NoteList NoteList { get; set; }
    }
}
