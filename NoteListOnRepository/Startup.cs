using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NoteList.Domain.Configuration;
using NoteList.Domain.Models;
using NoteListOnRepository.Interfaces;
using NoteListOnRepository.Services;

namespace NoteListOnRepository
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDataContext>(provider => provider.UseInMemoryDatabase("inmemory"));
            services.AddAutoMapper(config => config.AddProfile<ModelProfile>());

            services.AddTransient<IRepositoryAsync<NoteItem>, RepositoryAsync<NoteItem>>();
            services.AddTransient<IRepositoryAsync<NoteImage>, RepositoryAsync<NoteImage>>();
            services.AddTransient<IRepositoryAsync<NoteList.Domain.Models.NoteList>, RepositoryAsync<NoteList.Domain.Models.NoteList>>();
            services.AddTransient<IRepositoryAsync<Tag>, RepositoryAsync<Tag>>();
            services.AddTransient<NoteTagLinkRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NoteListOnRepository", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoteListOnRepository v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
