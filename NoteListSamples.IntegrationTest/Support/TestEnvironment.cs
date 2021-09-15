using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using NoteListSamples.IntegrationTest.Support.Facade;

namespace NoteListSamples.IntegrationTest.Support
{
    public class TestEnvironment
    {
        public readonly TestApplication TestApplication;

        public readonly HttpClient HttpClient;

        public readonly NoteImageFacade NoteImage;

        public readonly NoteItemFacade NoteItem;

        public readonly NoteListFacade NoteList;

        public TestEnvironment()
        {
            this.TestApplication = new();
            this.HttpClient = this.TestApplication.CreateClient();
            this.NoteImage = new(this.HttpClient);
            this.NoteItem = new(this.HttpClient);
            this.NoteList = new(this.HttpClient);
        }
    }
}
