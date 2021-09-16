using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using NoteList.IntegrationTest.Support.Services;
using NoteList.Service;
using NoteList.WebApi;
using System.Linq;

namespace NoteList.IntegrationTest.Support
{
    public class TestApplication : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dateTimeService = services.Single(
                    d => d.ServiceType ==
                        typeof(IDateTimeService));

                services.Remove(dateTimeService);

                services.AddSingleton<TimeHelperService>();
                services.AddSingleton<IDateTimeService, TestDateTimeService>();
            });
        }
    }
}
