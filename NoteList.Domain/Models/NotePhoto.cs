using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteList.Domain.Models
{
    public class NotePhoto
    {
        public Guid Id { get; set; }

        public byte[] Photo { get; set; }
    }
}
