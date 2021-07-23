using System;
using System.Net;
using System.Net.Http;
using NoteList.Domain.Commands;
using NoteList.Domain.Queries;
using NoteList.Domain.Models;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Encodings;
using System.Text;

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

        public async Task<List<EntityQuery>> Get()
        {
            HttpResponseMessage httpResponseMessage = await Client.GetAsync(FacadePath);
            string responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            List<EntityQuery> responseObject = JsonSerializer.Deserialize<List<EntityQuery>>(responseContentString, JsonSerializerOptions);
            
            return responseObject;
        }

        public async Task<EntityQuery> Get(int id)
        {
            HttpResponseMessage httpResponseMessage = await Client.GetAsync(FacadePath + $"/{id}");
            string responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            EntityQuery responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);
            
            return responseObject;
        }

        public async Task<EntityQuery> Post(EntityCommand entityCommand)
        {
            string requestContent = JsonSerializer.Serialize(entityCommand, JsonSerializerOptions);
            HttpResponseMessage httpResponseMessage = await Client.PostAsync(FacadePath, new StringContent(requestContent, Encoding.UTF8, "application/json"));
            string responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            EntityQuery responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);
            
            return responseObject;
        }
        
        public async Task<EntityQuery> Put(EntityCommand entityCommand)
        {
            string requestContent = JsonSerializer.Serialize(entityCommand, JsonSerializerOptions);
            HttpResponseMessage httpResponseMessage = await Client.PutAsync(FacadePath, new StringContent(requestContent, Encoding.UTF8, "application/json"));
            string responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            EntityQuery responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }

        public async Task<EntityQuery> Delete(int id)
        {
            HttpResponseMessage httpResponseMessage = await Client.DeleteAsync(FacadePath + $"/{id}");
            string responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            EntityQuery responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }
    }
}
