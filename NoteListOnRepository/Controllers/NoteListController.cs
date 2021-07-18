using Microsoft.AspNetCore.Mvc;
using NoteListOnRepository.Services;

namespace NoteListOnRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteListController : RestController<NoteList.Domain.Models.NoteList>
    {
        public NoteListController(RepositoryAsync<NoteList.Domain.Models.NoteList> repository)
            : base(repository) { }
    }
}
