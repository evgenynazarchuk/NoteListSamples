using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteList.Domain.Models
{
    public class NoteTagLink
    {
        public Guid NoteId { get; set; }

        public Note Note { get; set; }

        public Guid TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
