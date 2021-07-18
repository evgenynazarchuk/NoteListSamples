using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Models;
using NoteListOnRepository.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteListOnRepository.Controllers
{
    public class RestController<Entity> : ControllerBase
        where Entity : Identity, new()
    {
        protected readonly RepositoryAsync<Entity> Repository;

        public RestController(RepositoryAsync<Entity> repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public async Task<List<Entity>> Get()
        {
            return await Repository.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<Entity> Get(int id)
        {
            return await Repository.GetAsync(id);
        }

        [HttpPost]
        public async Task<Entity> Post(Entity entity)
        {
            return await Repository.CreateAsync(entity);
        }

        [HttpPut]
        public async Task<Entity> Put(Entity entity)
        {
            return await Repository.PutAsync(entity);
        }

        [HttpDelete]
        public async Task<Entity> Delete(int id)
        {
            return await Repository.DeleteAsync(id);
        }
    }
}
