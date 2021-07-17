using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteList.Domain.Models
{
    public class NoteItem
    {
        public Guid Id { get; set; }

        public string NoteText { get; set; }

        public Guid NoteImageId { get; set; }

        public NoteImage NoteImage { get; set; }

        public List<NoteTagLink> TagLinks { get; set; }

        public Guid NoteListId { get; set; }

        public NoteList NoteList { get; set; }
    }
}
