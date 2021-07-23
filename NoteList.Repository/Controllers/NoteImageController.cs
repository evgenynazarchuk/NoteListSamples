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
    public class NoteImageController : RestController<NoteImage, NoteImageCommand, NoteImageQuery>
    {
        public NoteImageController(IRepositoryAsync<NoteImage> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
