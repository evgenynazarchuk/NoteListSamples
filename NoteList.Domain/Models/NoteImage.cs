using NoteList.Domain.Interfaces;
using System;

namespace NoteList.Domain.Models
{
    public class NoteImage : Identity, ITimeTracker
    {
        public string ImageData { get; set; }

        public int NoteItemId { get; set; }

        public NoteItem NoteItem { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }
    }
}
