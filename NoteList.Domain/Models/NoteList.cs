using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteList.Domain.Models
{
    public class NoteList
    {
        public Guid Id { get; set; }

        public List<NoteItem> NoteItem { get; set; }
    }
}