using NoteList.Domain.Models;
using System.Net.Http;
using System.Text.Json;

namespace NoteList.WebApi.FacadeTests.Support.Helper.Facade
{
    public partial class NoteListFacadeHelper<EntityCommand, EntityQuery>
        : FacadeHelper<EntityCommand, EntityQuery>
        where EntityCommand : Identity
        where EntityQuery : Identity
    {
        public NoteListFacadeHelper(
            HttpClient httpClient,
            string facadePath,
            JsonSerializerOptions jsonSerializerOptions
            )
            : base(httpClient, facadePath, jsonSerializerOptions)
        { }
    }
}
