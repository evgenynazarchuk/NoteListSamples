using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Models;
using NoteList.Dto.Commands;
using NoteList.Dto.Queries;
using NoteList.Service;

namespace NoteList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteImageController : RestController<NoteImage, NoteImageCommand, NoteImageQuery>
    {
        public NoteImageController(INoteImageRepository repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
