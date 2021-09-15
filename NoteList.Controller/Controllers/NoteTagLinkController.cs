using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Dto.Commands;
using NoteList.Domain.Models;
using NoteList.Dto.Queries;
using NoteList.Services;
using System.Threading.Tasks;

namespace NoteList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NoteTagLinkController : ControllerBase
    {
        protected readonly INoteTagLinkRepository Repository;

        protected readonly IMapper Mapper;

        public NoteTagLinkController(INoteTagLinkRepository repository, IMapper mapper)
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
