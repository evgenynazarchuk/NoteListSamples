using NoteList.Domain.Interfaces;
using System;

namespace NoteList.Domain.Models
{
    public class NoteTagLink : ITimeTracker
    {
        public int NoteItemId { get; set; }

        public NoteItem NoteItem { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
