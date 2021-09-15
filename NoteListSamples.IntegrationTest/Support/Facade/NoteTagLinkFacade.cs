using System;
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
    public class NoteTagLinkFacade : Facade
    {
        public NoteTagLinkFacade(HttpClient httpClient)
            : base(httpClient) { }

        public ActionResult<NoteListQuery> GetById(int id)
        {
            var result = this.GetRequest<NoteListQuery>($"/NoteList/{id}");
            return result;
        }

        public ActionResult<List<NoteListQuery>> Get()
        {
            var result = this.GetRequest<List<NoteListQuery>>($"/NoteItem");
            return result;
        }

        public ActionResult<NoteListQuery> Post(NoteListCommand noteListCommand)
        {
            var result = this.PostRequest<NoteListQuery, NoteListCommand>("/NoteImage", noteListCommand);
            return result;
        }

        public ActionResult<NoteListQuery> Put(NoteListCommand noteListCommand)
        {
            var result = this.PutRequest<NoteListQuery, NoteListCommand>("/NoteImage", noteListCommand);
            return result;
        }

        public ActionResult<NoteListQuery> DeleteById(int id)
        {
            var result = this.DeleteRequest<NoteListQuery>($"/NoteImage/{id}");
            return result;
        }
    }
}
