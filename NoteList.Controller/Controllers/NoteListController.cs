using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Dto.Commands;
using NoteList.Dto.Queries;
using NoteList.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteListController : RestController<Domain.Models.NoteList, NoteListCommand, NoteListQuery>
    {
        public NoteListController(INoteListRepository repository, IMapper mapper)
            : base(repository, mapper) { }


        [HttpGet("{id}/Notes")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetNotes(int id)
        {
            var notes = await (Repository as INoteListRepository).GetNotes(id);
            var notesQuery = Mapper.Map<List<Domain.Models.NoteItem>, List<NoteItemQuery>>(notes);
            return Ok(notesQuery);
        }
    }
}
