﻿namespace NoteList.Domain.Commands
{
    public class NoteTagLinkCommand
    {
        public int NoteItemId { get; set; }

        public int TagId { get; set; }
    }
}
