using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Queries;
using NoteList.Repository.Interfaces;
using System;
using System.Threading.Tasks;

namespace NoteList.Repository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteListController : RestController<Domain.Models.NoteList, NoteListCommand, NoteListQuery>
    {
        public NoteListController(IRepositoryAsync<Domain.Models.NoteList> repository, IMapper mapper)
            : base(repository, mapper) { }


        [HttpGet("{id}/Notes")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetNotes(int id)
        {
            throw new ApplicationException("not implemented");
        }
    }
}
