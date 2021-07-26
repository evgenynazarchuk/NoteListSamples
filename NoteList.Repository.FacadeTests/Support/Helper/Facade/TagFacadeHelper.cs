using NoteList.Domain.Models;
using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NoteList.Domain.Queries;

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

        public async Task<List<NoteItemQuery>> GetNotes(int id)
        {
            var httpResponseMessage = await Client.GetAsync(FacadePath + $"/{id}/Notes");
            var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<List<NoteItemQuery>>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }
    }
}
