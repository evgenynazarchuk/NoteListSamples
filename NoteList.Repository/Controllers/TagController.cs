﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;
using NoteList.Repository.Interfaces;

namespace NoteList.Repository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TagController : RestController<Tag, TagCommand, TagQuery>
    {
        public TagController(IRepositoryAsync<Tag> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}