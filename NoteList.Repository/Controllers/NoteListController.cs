﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Queries;
using NoteList.Repository.Interfaces;

namespace NoteList.Repository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteListController : RestController<NoteList.Domain.Models.NoteList, NoteListCommand, NoteListQuery>
    {
        public NoteListController(IRepositoryAsync<NoteList.Domain.Models.NoteList> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}