﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;

namespace NoteListSamples.IntegrationTest.Support.Facade
{
    public class NoteItemFacade : Facade
    {
        public NoteItemFacade(HttpClient httpClient)
            : base(httpClient) { }

        public ActionResult<NoteItemQuery> GetById(int id)
        {
            var result = this.GetRequest<NoteItemQuery>($"/NoteItem/{id}");
            return result;
        }

        public ActionResult<List<NoteItemQuery>> Get()
        {
            var result = this.GetRequest<List<NoteItemQuery>>($"/NoteItem");
            return result;
        }

        public ActionResult<NoteItemQuery> Post(NoteItemCommand noteItemCommand)
        {
            var result = this.PostRequest<NoteItemQuery, NoteItemCommand>("/NoteImage", noteItemCommand);
            return result;
        }

        public ActionResult<NoteItemQuery> Put(NoteItemCommand noteItemCommand)
        {
            var result = this.PutRequest<NoteItemQuery, NoteItemCommand>("/NoteImage", noteItemCommand);
            return result;
        }

        public ActionResult<NoteItemQuery> DeleteById(int id)
        {
            var result = this.DeleteRequest<NoteItemQuery>($"/NoteImage/{id}");
            return result;
        }

        public ActionResult<List<TagQuery>> GetTags(int id)
        {
            var result = this.GetRequest<List<TagQuery>>($"/NoteItem/{id}/Tags");
            return result;
        }
    }
}
