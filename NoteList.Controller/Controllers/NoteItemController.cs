using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Dto.Commands;
using NoteList.Domain.Models;
using NoteList.Dto.Queries;
using NoteList.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteItemController : RestController<NoteItem, NoteItemCommand, NoteItemQuery>
    {
        public NoteItemController(INoteItemRepository repository, IMapper mapper)
            : base(repository, mapper) { }

        [HttpGet("{id}/Tags")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<List<TagQuery>> GetTags(int id)
        {
            var tags = await (Repository as INoteItemRepository).GetTags(id);
            var tagsQuery = Mapper.Map<List<Tag>, List<TagQuery>>(tags);
            return tagsQuery;
        }
    }
}
