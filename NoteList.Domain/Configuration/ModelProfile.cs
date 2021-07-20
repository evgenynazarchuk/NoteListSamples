using AutoMapper;
using NoteList.Domain.Commands;
using NoteList.Domain.Models;
using NoteList.Domain.Queries;

namespace NoteList.Domain.Configuration
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<NoteImageCommand, NoteImage>();
            CreateMap<NoteImage, NoteImageQuery>();

            CreateMap<NoteItemCommand, NoteItem>();
            CreateMap<NoteItem, NoteItemQuery>();

            CreateMap<NoteListCommand, NoteList.Domain.Models.NoteList>();
            CreateMap<NoteList.Domain.Models.NoteList, NoteListQuery>();

            CreateMap<TagCommand, Tag>();
            CreateMap<Tag, TagQuery>();
        }
    }
}
