using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;
using NoteList.Repository.Interfaces;
using System.Threading.Tasks;
using System;

namespace NoteList.Repository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteItemController : RestController<NoteItem, NoteItemCommand, NoteItemQuery>
    {
        public NoteItemController(IRepositoryAsync<NoteItem> repository, IMapper mapper)
            : base(repository, mapper) { }

        [HttpGet("{id}/Tags")]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<IActionResult> GetTags(int id)
        {
            throw new ApplicationException("not implemented");
        }
    }
}
