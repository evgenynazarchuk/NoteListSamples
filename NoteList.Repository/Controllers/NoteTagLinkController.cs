using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;
using NoteList.Repository.Services;
using System.Threading.Tasks;

namespace NoteList.Repository.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NoteTagLinkController : ControllerBase
    {
        protected readonly NoteTagLinkRepository Repository;

        protected readonly IMapper Mapper;

        public NoteTagLinkController(NoteTagLinkRepository repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        [HttpPost]
        public async Task<NoteTagLinkQuery> CreateLink(NoteTagLinkCommand link)
        {
            var entity = Mapper.Map<NoteTagLinkCommand, NoteTagLink>(link);
            var createdEntity = await Repository.CreateLinkAsync(entity);
            var entityQuery = Mapper.Map<NoteTagLink, NoteTagLinkQuery>(createdEntity);
            return entityQuery;
        }

        [HttpPost]
        public async Task<NoteTagLinkQuery> RemoveLink(NoteTagLinkCommand link)
        {
            var entity = Mapper.Map<NoteTagLinkCommand, NoteTagLink>(link);
            var createdEntity = await Repository.RemoveLinkAsync(entity);
            var entityQuery = Mapper.Map<NoteTagLink, NoteTagLinkQuery>(createdEntity);
            return entityQuery;
        }
    }
}
