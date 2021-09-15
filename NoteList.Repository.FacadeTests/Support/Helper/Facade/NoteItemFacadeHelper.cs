using NoteList.Domain.Models;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using NoteList.Domain.Queries;

namespace NoteList.WebApi.FacadeTests.Support.Helper.Facade
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

        public async Task<List<TagQuery>> GetTags(int id)
        {
            var httpResponseMessage = await Client.GetAsync(FacadePath + $"/{id}/Tags");
            var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<List<TagQuery>>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }
    }
}
