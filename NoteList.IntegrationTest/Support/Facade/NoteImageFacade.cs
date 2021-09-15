using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;

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
