namespace NoteList.Domain.Commands
{
    public class NoteTagLinkCommand
    {
        public int NoteId { get; set; }

        public int TagId { get; set; }
    }
}
