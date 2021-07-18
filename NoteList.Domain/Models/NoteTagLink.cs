namespace NoteList.Domain.Models
{
    public class NoteTagLink
    {
        public int NoteItemId { get; set; }

        public NoteItem NoteItem { get; set; }

        public int TagId { get; set; }

        public Tag Tag { get; set; }
    }
}
