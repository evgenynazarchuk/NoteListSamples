using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteList.Domain.Models;

namespace NoteList.Domain.Queries
{
    public class TagQuery : Identity
    {
        public string Name { get; set; }
    }
}
