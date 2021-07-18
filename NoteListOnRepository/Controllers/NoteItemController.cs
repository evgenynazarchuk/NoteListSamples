using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Models;
using NoteListOnRepository.Services;

namespace NoteListOnRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteItemController : RestController<NoteItem>
    {
        public NoteItemController(RepositoryAsync<NoteItem> repository)
            : base(repository) { }
    }
}
