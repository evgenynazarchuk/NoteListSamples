namespace NoteList.Domain.Models
{
    public class NoteImage : Identity
    {
        public string ImageData { get; set; }

        public int NoteItemId { get; set; }

        public NoteItem NoteItem { get; set; }
    }
}
