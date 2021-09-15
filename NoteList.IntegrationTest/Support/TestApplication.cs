using Microsoft.AspNetCore.Mvc.Testing;
using NoteList.WebApi;

namespace NoteList.IntegrationTest.Support
{
    public class TestApplication : WebApplicationFactory<Startup>
    {
    }
}
