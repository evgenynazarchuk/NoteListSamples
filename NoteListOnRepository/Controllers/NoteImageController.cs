using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Models;
using NoteListOnRepository.Services;

namespace NoteListOnRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteImageController : RestController<NoteImage>
    {
        public NoteImageController(RepositoryAsync<NoteImage> repository)
            : base(repository) { }
    }
}
