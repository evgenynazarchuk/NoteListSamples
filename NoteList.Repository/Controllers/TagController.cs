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
    public class TagController : RestController<Tag, TagCommand, TagQuery>
    {
        public TagController(TagRepositoryAsync repository, IMapper mapper)
            : base(repository, mapper) { }

        [HttpGet("{id}/Notes")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<List<NoteItemQuery>> GetNotes(int id)
        {
            var notes = await (Repository as TagRepositoryAsync).GetNotes(id);
            var notesQuery = Mapper.Map<List<NoteItem>, List<NoteItemQuery>>(notes);
            return notesQuery;
        }
    }
}
