using BenchmarkDotNet.Attributes;
using NoteList.Domain.Commands;
using NoteList.Repository.FacadeTests.Support;
using System.Threading.Tasks;

namespace NoteList.Repository.BenchmarkTests
{
    [HtmlExporter]
    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class NoteItemTests
    {
        public WebApp WebApp;
        public int DefaultListId;

        [GlobalSetup]
        public async Task GlobalSetup()
        {
            WebApp = new WebApp();

            var list = await WebApp.ListFacade.PostAsync(new NoteListCommand
            {
                Name = "Test Name"
            });

            DefaultListId = list.Id;
        }

        [Benchmark]
        public async Task CreateNoteItem()
        {
            await WebApp.ItemFacade.PostAsync(new NoteItemCommand
            {
                NoteText = "Any Note Text",
                NoteListId = DefaultListId
            });
        }
    }
}
