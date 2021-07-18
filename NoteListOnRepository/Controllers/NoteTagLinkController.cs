using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Models;
using NoteListOnRepository.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NoteListOnRepository.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NoteTagLinkController : ControllerBase
    {
        protected readonly NoteTagLinkRepository Repository;

        public NoteTagLinkController(NoteTagLinkRepository repository)
        {
            Repository = repository;
        }

        [HttpPost]
        public async Task CreateLink(NoteTagLink link)
        {
            await Repository.CreateLinkAsync(link);
        }

        [HttpDelete]
        public async Task RemoveLink(NoteTagLink link)
        {
            await Repository.RemoveLinkAsync(link);
        }

        [HttpGet]
        public async Task<List<NoteTagLink>> GetLinks()
        {
            return await Repository.GetLinksAsync();
        }

        [HttpGet]
        public async Task<List<NoteItem>> GetNotesByTag(int tagId)
        {
            return await Repository.GetNotesByTagAsync(tagId);
        }

        [HttpGet]
        public async Task<List<Tag>> GetTagsByNote(int noteId)
        {
            return await Repository.GetTagsByNoteAsync(noteId);
        }
    }
}
