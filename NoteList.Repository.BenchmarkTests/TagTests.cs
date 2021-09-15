using BenchmarkDotNet.Attributes;
using NoteList.Domain.Commands;
using NoteList.WebApi.FacadeTests.Support;
using System.Threading.Tasks;

namespace NoteList.WebApi.BenchmarkTests
{
    [HtmlExporter]
    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class TagTests
    {
        public WebApp WebApp;

        [GlobalSetup]
        public void GlobalSetup()
        {
            WebApp = new WebApp();
        }

        [Benchmark]
        public async Task CreateTag()
        {
            await WebApp.TagFacade.PostAsync(new TagCommand
            {
                Name = "Test Name"
            });
        }
    }
}
