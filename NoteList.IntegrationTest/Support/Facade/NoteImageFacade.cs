using NoteList.Dto.Commands;
using NoteList.Dto.Queries;
using System.Collections.Generic;
using System.Net.Http;

namespace NoteList.IntegrationTest.Support.Facade
{
    public class NoteImageFacade : Facade
    {
        public NoteImageFacade(HttpClient httpClient)
            : base(httpClient) { }

        public ActionResult<NoteListQuery> GetById(int id)
        {
            var result = this.GetRequest<NoteListQuery>($"/NoteImage/{id}");
            return result;
        }

        public ActionResult<List<NoteListQuery>> Get()
        {
            var result = this.GetRequest<List<NoteListQuery>>($"/NoteImage");
            return result;
        }

        public ActionResult<NoteImageQuery> Post(NoteImageCommand noteImageCommand)
        {
            var result = this.PostRequest<NoteImageQuery, NoteImageCommand>("/NoteImage", noteImageCommand);
            return result;
        }

        public ActionResult<NoteImageQuery> Put(NoteImageCommand noteImageCommand)
        {
            var result = this.PutRequest<NoteImageQuery, NoteImageCommand>("/NoteImage", noteImageCommand);
            return result;
        }

        public ActionResult<NoteListQuery> DeleteById(int id)
        {
            var result = this.DeleteRequest<NoteListQuery>($"/NoteImage/{id}");
            return result;
        }
    }
}
