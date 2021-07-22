using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace NoteList.Repository.FacadeTests.Support
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
