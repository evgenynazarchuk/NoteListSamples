using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteList.Domain.Models
{
    public class Note
    {
        public Guid Id { get; set; }

        public Guid NoteListId { get; set; }

        public NoteList NoteList { get; set; }

        public List<NoteTagLink> TagLinks { get; set; }

        public string Text { get; set; }

        public byte[] Photo { get; set; }
    }
}
