using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Queries;
using NoteList.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteListController : RestController<Domain.Models.NoteList, NoteListCommand, NoteListQuery>
    {
        public NoteListController(NoteListRepository repository, IMapper mapper)
            : base(repository, mapper) { }


        [HttpGet("{id}/Notes")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetNotes(int id)
        {
            var notes = await (Repository as NoteListRepository).GetNotes(id);
            var notesQuery = Mapper.Map<List<Domain.Models.NoteItem>, List<NoteItemQuery>>(notes);
            return Ok(notesQuery);
        }
    }
}
