using System;
using System.Net;
using System.Net.Http;
using NoteList.Domain.Commands;
using NoteList.Domain.Queries;
using NoteList.Domain.Models;
using System.Text.Json;

namespace NoteList.Repository.FacadeTests.Support.Helper.Facade
{
    public partial class NoteImageFacadeHelper<EntityCommand, EntityQuery> 
        : FacadeHelper<EntityCommand, EntityQuery>
        where EntityCommand : Identity
        where EntityQuery : Identity
    {
        public NoteImageFacadeHelper(
            HttpClient httpClient, 
            string facadePath,
            JsonSerializerOptions jsonSerializerOptions)
            : base(httpClient, facadePath, jsonSerializerOptions
            ) 
        { }
    }
}
