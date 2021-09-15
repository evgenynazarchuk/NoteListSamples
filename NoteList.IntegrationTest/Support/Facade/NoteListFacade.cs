using NoteList.Dto.Commands;
using NoteList.Dto.Queries;
using System.Collections.Generic;
using System.Net.Http;

namespace NoteList.IntegrationTest.Support.Facade
{
    public class NoteListFacade : Facade
    {
        public NoteListFacade(HttpClient httpClient)
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
