using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Models;
using NoteList.Dto.Commands;
using NoteList.Dto.Queries;
using NoteList.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : RestController<Tag, TagCommand, TagQuery>
    {
        public TagController(ITagRepository repository, IMapper mapper)
            : base(repository, mapper) { }

        [HttpGet("{id}/Notes")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetNotes(int id)
        {
            var notes = await (Repository as ITagRepository).GetNotes(id);
            var notesQuery = Mapper.Map<List<NoteItem>, List<NoteItemQuery>>(notes);
            return Ok(notesQuery);
        }
    }
}
