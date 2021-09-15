using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;
using System.Threading.Tasks;
using System;
using NoteList.Services.Impl;
using NoteList.Services;
using System.Collections.Generic;

namespace NoteList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteItemController : RestController<NoteItem, NoteItemCommand, NoteItemQuery>
    {
        public NoteItemController(NoteItemRepository repository, IMapper mapper)
            : base(repository, mapper) { }

        [HttpGet("{id}/Tags")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<List<TagQuery>> GetTags(int id)
        {
            var tags = await (Repository as NoteItemRepository).GetTags(id);
            var tagsQuery = Mapper.Map<List<Tag>, List<TagQuery>>(tags);
            return tagsQuery;
        }
    }
}
