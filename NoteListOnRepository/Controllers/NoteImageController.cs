﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;
using NoteListOnRepository.Interfaces;

namespace NoteListOnRepository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteImageController : RestController<NoteImage, NoteImageCommand, NoteListQuery>
    {
        public NoteImageController(IRepositoryAsync<NoteImage> repository, IMapper mapper)
            : base(repository, mapper) { }
    }
}
