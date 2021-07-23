using System.Collections.Generic;

namespace NoteList.Domain.Models
{
    public class Tag : Identity
    {
        public string Name { get; set; }

        public List<NoteTagLink> NoteLinks { get; set; }

        public List<NoteItem> NoteItems { get; set; }
    }
}
