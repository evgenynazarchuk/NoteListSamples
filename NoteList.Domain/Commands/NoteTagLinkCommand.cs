using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteList.Domain.Commands
{
    public class NoteTagLinkCommand
    {
        public int NoteId { get; set; }

        public int TagId { get; set; }
    }
}
