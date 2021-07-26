﻿using BenchmarkDotNet.Attributes;
using NoteList.Domain.Commands;
using NoteList.Repository.FacadeTests.Support;
using System.Threading.Tasks;

namespace NoteList.Repository.BenchmarkTests
{
    [HtmlExporter]
    [MemoryDiagnoser]
    [MinColumn, MaxColumn, MeanColumn, MedianColumn]
    public class ListTests
    {
        public WebApp WebApp;

        [GlobalSetup]
        public void GlobalSetup()
        {
            WebApp = new WebApp();
        }

        [Benchmark]
        public async Task CreateList()
        {
            await WebApp.ListFacade.PostAsync(new NoteListCommand
            {
                Name = "Test Name"
            });
        }
    }
}