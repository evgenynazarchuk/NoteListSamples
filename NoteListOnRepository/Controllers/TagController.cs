using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Models;
using NoteListOnRepository.Services;

namespace NoteListOnRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : RestController<Tag>
    {
        public TagController(RepositoryAsync<Tag> repository)
            : base(repository) { }
    }
}
