using NoteList.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace NoteList.Domain.Models
{
    public class Tag : Identity, ITimeTracker
    {
        public string Name { get; set; }

        public List<NoteTagLink> NoteLinks { get; set; }

        public List<NoteItem> NoteItems { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
