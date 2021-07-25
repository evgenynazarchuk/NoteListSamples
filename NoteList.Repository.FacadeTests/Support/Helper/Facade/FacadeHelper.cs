﻿using NoteList.Domain.Models;
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
            var httpResponseMessage = await Client.GetAsync(FacadePath);
            var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<List<EntityQuery>>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }

        public async Task<EntityQuery> GetAsync(int id)
        {
            var httpResponseMessage = await Client.GetAsync(FacadePath + $"/{id}");
            var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }

        public async Task<EntityQuery> PostAsync(EntityCommand entityCommand)
        {
            var requestContent = JsonSerializer.Serialize(entityCommand, JsonSerializerOptions);
            var httpResponseMessage = await Client.PostAsync(FacadePath, new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }

        public async Task<EntityQuery> PutAsync(EntityCommand entityCommand)
        {
            var requestContent = JsonSerializer.Serialize(entityCommand, JsonSerializerOptions);
            var httpResponseMessage = await Client.PutAsync(FacadePath, new StringContent(requestContent, Encoding.UTF8, "application/json"));
            var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }

        public async Task<EntityQuery> DeleteAsync(int id)
        {
            var httpResponseMessage = await Client.DeleteAsync(FacadePath + $"/{id}");
            var responseContentString = await httpResponseMessage.Content.ReadAsStringAsync();
            var responseObject = JsonSerializer.Deserialize<EntityQuery>(responseContentString, JsonSerializerOptions);

            return responseObject;
        }
    }
}
