using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;
using NoteList.Services.Impl;
using NoteList.Services;

namespace NoteList.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteImageController : RestController<NoteImage, NoteImageCommand, NoteImageQuery>
    {
        public NoteImageController(IRepository<NoteImage> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
