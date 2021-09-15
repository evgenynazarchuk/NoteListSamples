﻿using NoteList.IntegrationTest.Support.Facade;
using System.Net.Http;

namespace NoteList.IntegrationTest.Support
{
    public class TestEnvironment
    {
        public readonly TestApplication TestApplication;

        public readonly HttpClient HttpClient;

        public readonly NoteImageFacade NoteImage;

        public readonly NoteItemFacade NoteItem;

        public readonly NoteListFacade NoteList;

        public readonly NoteTagLinkFacade NoteTagLink;

        public readonly TagFacade Tag;

        public TestEnvironment()
        {
            this.TestApplication = new();
            this.HttpClient = this.TestApplication.CreateClient();

            this.NoteImage = new(this.HttpClient);
            this.NoteItem = new(this.HttpClient);
            this.NoteList = new(this.HttpClient);
            this.NoteTagLink = new(this.HttpClient);
            this.Tag = new(this.HttpClient);
        }
    }
}
