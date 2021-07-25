using NoteList.Domain.Models;
using System.Net.Http;
using System.Text.Json;

namespace NoteList.Repository.FacadeTests.Support.Helper.Facade
{
    public class TagFacadeHelper<EntityCommand, EntityQuery>
        : FacadeHelper<EntityCommand, EntityQuery>
        where EntityCommand : Identity
        where EntityQuery : Identity
    {
        public TagFacadeHelper(
            HttpClient httpClient,
            string facadePath,
            JsonSerializerOptions jsonSerializerOptions
            )
            : base(httpClient, facadePath, jsonSerializerOptions)
        { }
    }
}
