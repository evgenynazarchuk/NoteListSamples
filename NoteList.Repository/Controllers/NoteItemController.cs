using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;
using NoteList.Repository.Interfaces;
using System.Threading.Tasks;
using System;
using NoteList.Repository.Services;
using System.Collections.Generic;

namespace NoteList.Repository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteItemController : RestController<NoteItem, NoteItemCommand, NoteItemQuery>
    {
        public NoteItemController(NoteItemRepositoryAsync repository, IMapper mapper)
            : base(repository, mapper) { }

        [HttpGet("{id}/Tags")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<List<TagQuery>> GetTags(int id)
        {
            var tags = await (Repository as NoteItemRepositoryAsync).GetTags(id);
            var tagsQuery = Mapper.Map<List<Tag>, List<TagQuery>>(tags);
            return tagsQuery;
        }
    }
}
