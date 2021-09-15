using AutoMapper;
using NoteList.Dto.Commands;
using NoteList.Domain.Models;
using NoteList.Dto.Queries;

namespace NoteList.Dto.Configuration
{
    public class ModelProfile : Profile
    {
        public ModelProfile()
        {
            CreateMap<NoteImageCommand, NoteImage>();
            CreateMap<NoteImage, NoteImageQuery>();

            CreateMap<NoteItemCommand, NoteItem>();
            CreateMap<NoteItem, NoteItemQuery>();

            CreateMap<NoteListCommand, Domain.Models.NoteList>();
            CreateMap<Domain.Models.NoteList, NoteListQuery>();

            CreateMap<TagCommand, Tag>();
            CreateMap<Tag, TagQuery>();

            CreateMap<NoteTagLinkCommand, NoteTagLink>();
            CreateMap<NoteTagLink, NoteTagLinkQuery>();
        }
    }
}
