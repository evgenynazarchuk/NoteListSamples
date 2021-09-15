using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using NoteList.Services.Impl;
using NoteList.Services;

namespace NoteList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : RestController<Tag, TagCommand, TagQuery>
    {
        public TagController(TagRepository repository, IMapper mapper)
            : base(repository, mapper) { }

        [HttpGet("{id}/Notes")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetNotes(int id)
        {
            var notes = await (Repository as TagRepository).GetNotes(id);
            var notesQuery = Mapper.Map<List<NoteItem>, List<NoteItemQuery>>(notes);
            return Ok(notesQuery);
        }
    }
}
