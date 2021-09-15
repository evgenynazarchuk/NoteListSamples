using NoteList.Domain.Models;
using System.Net.Http;
using System.Text.Json;

namespace NoteList.WebApi.FacadeTests.Support.Helper.Facade
{
    public partial class NoteImageFacadeHelper<EntityCommand, EntityQuery>
        : FacadeHelper<EntityCommand, EntityQuery>
        where EntityCommand : Identity
        where EntityQuery : Identity
    {
        public NoteImageFacadeHelper(
            HttpClient httpClient,
            string facadePath,
            JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, facadePath, jsonSerializerOptions
            )
        { }
    }
}
