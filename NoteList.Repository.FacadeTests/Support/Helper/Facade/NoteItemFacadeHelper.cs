using NoteList.Domain.Models;
using System.Net.Http;
using System.Text.Json;

namespace NoteList.Repository.FacadeTests.Support.Helper.Facade
{
    public partial class NoteItemFacadeHelper<EntityCommand, EntityQuery>
        : FacadeHelper<EntityCommand, EntityQuery>
        where EntityCommand : Identity
        where EntityQuery : Identity
    {
        public NoteItemFacadeHelper(
            HttpClient httpClient,
            string facadePath,
            JsonSerializerOptions jsonSerializerOptions
            )
            : base(httpClient, facadePath, jsonSerializerOptions)
        { }
    }
}
