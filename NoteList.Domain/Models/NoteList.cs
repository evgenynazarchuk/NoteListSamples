using System.Collections.Generic;

namespace NoteList.Domain.Models
{
    public class NoteList : Identity
    {
        public string Name { get; set; }
        public List<NoteItem> NoteItem { get; set; }
    }
}