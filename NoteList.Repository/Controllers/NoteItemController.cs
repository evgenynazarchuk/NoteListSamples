using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;
using NoteList.Repository.Interfaces;

namespace NoteList.Repository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteItemController : RestController<NoteItem, NoteItemCommand, NoteItemQuery>
    {
        public NoteItemController(IRepositoryAsync<NoteItem> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
