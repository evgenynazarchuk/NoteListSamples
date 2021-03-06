using NoteList.Dto.Commands;
using NoteList.Dto.Queries;
using System.Collections.Generic;
using System.Net.Http;

namespace NoteList.IntegrationTest.Support.Facade
{
    public class TagFacade : Facade
    {
        public TagFacade(HttpClient httpClient)
            : base(httpClient) { }

        public ActionResult<TagQuery> GetById(int id)
        {
            var result = this.GetRequest<TagQuery>($"/Tag/{id}");
            return result;
        }

        public ActionResult<List<TagQuery>> Get()
        {
            var result = this.GetRequest<List<TagQuery>>($"/Tag");
            return result;
        }

        public ActionResult<TagQuery> Post(TagCommand noteListCommand)
        {
            var result = this.PostRequest<TagQuery, TagCommand>("/Tag", noteListCommand);
            return result;
        }

        public ActionResult<TagQuery> Put(TagCommand noteListCommand)
        {
            var result = this.PutRequest<TagQuery, TagCommand>("/Tag", noteListCommand);
            return result;
        }

        public ActionResult<TagQuery> DeleteById(int id)
        {
            var result = this.DeleteRequest<TagQuery>($"/Tag/{id}");
            return result;
        }

        public ActionResult<List<NoteItemQuery>> GetNotes(int id)
        {
            var result = this.GetRequest<List<NoteItemQuery>>($"/Tag/{id}/Notes");
            return result;
        }
    }
}
