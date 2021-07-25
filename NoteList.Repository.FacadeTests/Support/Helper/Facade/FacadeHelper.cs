using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NoteList.Repository.FacadeTests.Support.Helper.Facade
{
    public abstract class FacadeHelper<EntityCommand, EntityQuery>
        where EntityCommand : Identity
        where EntityQuery : Identity
    {
        protected HttpClient Client { get; set; }
        protected string FacadePath { get; set; }
        protected JsonSerializerOptions JsonSerializerOptions { get; set; }

        public FacadeHelper(
            HttpClient httpClient,
            string facadePath,
            JsonSerializerOptions jsonSerializerOptions
            )
        {
            Client = httpClient;
            FacadePath = facadePath;
            JsonSerializerOptions = jsonSerializerOptions;
        }

        public async Task<List<EntityQuery>> GetAsync()
        {
            HttpResponseMessage httpResponseMessage = await Client.GetAsync(FacadePath);
            string responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            List<EntityQuery> responseObject = JsonSerializer.Deserialize<List<EntityQuery>>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }

        public async Task<EntityQuery> GetAsync(int id)
        {
            HttpResponseMessage httpResponseMessage = await Client.GetAsync(FacadePath + $"/{id}");
            string responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            EntityQuery responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }

        public async Task<EntityQuery> PostAsync(EntityCommand entityCommand)
        {
            string requestContent = JsonSerializer.Serialize(entityCommand, JsonSerializerOptions);
            HttpResponseMessage httpResponseMessage = await Client.PostAsync(FacadePath, new StringContent(requestContent, Encoding.UTF8, "application/json"));
            string responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            EntityQuery responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }

        public async Task<EntityQuery> PutAsync(EntityCommand entityCommand)
        {
            string requestContent = JsonSerializer.Serialize(entityCommand, JsonSerializerOptions);
            HttpResponseMessage httpResponseMessage = await Client.PutAsync(FacadePath, new StringContent(requestContent, Encoding.UTF8, "application/json"));
            string responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            EntityQuery responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }

        public async Task<EntityQuery> DeleteAsync(int id)
        {
            HttpResponseMessage httpResponseMessage = await Client.DeleteAsync(FacadePath + $"/{id}");
            string responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            EntityQuery responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }
    }
}
