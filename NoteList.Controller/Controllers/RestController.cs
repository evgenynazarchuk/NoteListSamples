using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Models;
using NoteList.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.WebApi.Controllers
{
    public class RestController<Entity, EntityCommand, EntityQuery> : ControllerBase
        where Entity : Identity, new()
        where EntityCommand : Identity, new()
        where EntityQuery : Identity, new()
    {
        protected readonly IRepository<Entity> Repository;

        protected readonly IMapper Mapper;

        public RestController(IRepository<Entity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<List<EntityQuery>> Get()
        {
            var entities = await Repository.GetAsync();
            var entitiesQuery = Mapper.Map<List<Entity>, List<EntityQuery>>(entities);
            return entitiesQuery;
        }

        [HttpGet("{id}")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<EntityQuery> Get(int id)
        {
            var entity = await Repository.GetAsync(id);
            var entityQuery = Mapper.Map<Entity, EntityQuery>(entity);
            return entityQuery;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<EntityQuery> Post(EntityCommand entityCommand)
        {
            var entity = Mapper.Map<EntityCommand, Entity>(entityCommand);
            var createdEntity = await Repository.CreateAsync(entity);
            var entityQuery = Mapper.Map<Entity, EntityQuery>(createdEntity);
            return entityQuery;
        }

        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<EntityQuery> Put(EntityCommand entityCommand)
        {
            var entity = Mapper.Map<EntityCommand, Entity>(entityCommand);
            var createdEntity = await Repository.PutAsync(entity);
            var entityQuery = Mapper.Map<Entity, EntityQuery>(createdEntity);
            return entityQuery;
        }

        [HttpDelete]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<EntityQuery> Delete(int id)
        {
            var entity = await Repository.DeleteAsync(id);
            var entityQuery = Mapper.Map<Entity, EntityQuery>(entity);
            return entityQuery;
        }
    }
}
