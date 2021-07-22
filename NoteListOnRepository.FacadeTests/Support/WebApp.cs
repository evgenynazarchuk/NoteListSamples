using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using NoteListOnRepository;
using Microsoft.Extensions.Logging;

namespace NoteListOnRepository.FacadeTests.Support
{
    public class WebApp : WebApplicationFactory<Startup>
    {
        public WebApp()
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // delete original db context
                var originalAppDataContext = services.SingleOrDefault(
                    d => d.ServiceType ==
                        typeof(DbContextOptions<AppDataContext>));
                services.Remove(originalAppDataContext);

                // insert db in memory context
                services.AddDbContext<AppDataContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                // create scheme in memory
                var sp = services.BuildServiceProvider();
                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<AppDataContext>();
                db.Database.EnsureCreated();
            });
        }
    }
}
