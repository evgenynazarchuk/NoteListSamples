using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteList.Domain.Models
{
    public class NoteImage
    {
        public Guid Id { get; set; }

        public byte[] Image { get; set; }

        public Guid NoteItemId { get; set; }

        public NoteItem NoteItem { get; set; }
    }
}
