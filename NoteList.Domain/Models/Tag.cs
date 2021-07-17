using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteList.Domain.Models
{
    public class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<NoteTagLink> NoteLinks { get; set; }
    }
}
