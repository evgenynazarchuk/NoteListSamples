using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NoteList.WebApi;
using System.Net.Http;

namespace NoteList.IntegrationTest.Support
{
    public class TestApplication : WebApplicationFactory<Startup>
    {
    }
}
