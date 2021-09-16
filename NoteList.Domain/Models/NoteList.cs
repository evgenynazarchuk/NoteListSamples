using NoteList.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace NoteList.Domain.Models
{
    public class NoteList : Identity, ITimeTracker
    {
        public string Name { get; set; }

        public List<NoteItem> NoteItem { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}