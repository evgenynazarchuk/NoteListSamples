using NoteList.Domain.Commands;
using NoteList.Domain.Queries;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NoteList.Repository.FacadeTests.Support.Helper.Facade
{
    public sealed class NoteTagLinkFacadeHelper
    {
        private readonly JsonSerializerOptions JsonSerializerOptions;
        private readonly HttpClient HttpClient;
        private readonly string FacadePath;

        public NoteTagLinkFacadeHelper(
            HttpClient httpClient,
            string facadePath,
            JsonSerializerOptions jsonSerializerOptions
            )
        {
            HttpClient = httpClient;
            FacadePath = facadePath;
            JsonSerializerOptions = jsonSerializerOptions;
        }

        public async Task<NoteTagLinkQuery> CreateLink(NoteTagLinkCommand noteTagLinkCommand)
        {
            var requestContent = JsonSerializer.Serialize(noteTagLinkCommand, JsonSerializerOptions);
            var httpResponseMessage = await HttpClient.PostAsync(FacadePath + "/CreateLink", new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<NoteTagLinkQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }

        public async Task<NoteTagLinkQuery> RemoveLink(NoteTagLinkCommand noteTagLinkCommand)
        {
            var requestContent = JsonSerializer.Serialize(noteTagLinkCommand, JsonSerializerOptions);
            var httpResponseMessage = await HttpClient.PostAsync(FacadePath + "/RemoveLink", new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<NoteTagLinkQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }
    }
}
