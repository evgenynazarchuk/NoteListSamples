using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NoteList.Domain.Commands;
using NoteList.Domain.Queries;
using NoteList.Repository.FacadeTests.Support.Helper.Facade;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

namespace NoteList.Repository.FacadeTests.Support
{
    public class WebApp : WebApplicationFactory<Startup>
    {
        public NoteImageFacadeHelper<NoteImageCommand, NoteImageQuery> ImageFacade { get; set; }

        public NoteItemFacadeHelper<NoteItemCommand, NoteItemQuery> ItemFacade { get; set; }

        public NoteListFacadeHelper<NoteListCommand, NoteListQuery> ListFacade { get; set; }

        public TagFacadeHelper<TagCommand, TagQuery> TagFacade { get; set; }

        public NoteTagLinkFacadeHelper NoteTagLink { get; set; }

        protected readonly JsonSerializerOptions JsonSerializerOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        protected HttpClient Client { get; set; }

        public WebApp()
        {
            Client = CreateClient();

            ImageFacade = new(Client, "/NoteImage", JsonSerializerOptions);
            ItemFacade = new(Client, "/NoteItem", JsonSerializerOptions);
            ListFacade = new(Client, "/NoteList", JsonSerializerOptions);
            TagFacade = new(Client, "/Tag", JsonSerializerOptions);
            NoteTagLink = new(Client, "/NoteTagLink", JsonSerializerOptions);
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
