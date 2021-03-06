using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NoteList.Dto.Configuration;
using NoteList.Service;
using NoteList.Service.Impl;

namespace NoteList.WebApi
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
            using (var db = new DataContext(new DateTimeService()))
            {
                db.Database.EnsureCreated();
            }

            services.AddSingleton<IDateTimeService, DateTimeService>();
            //services.AddScoped<IDataContext, DataContext>();
            services.AddScoped<DataContext>();

            services.AddAutoMapper(config => config.AddProfile<ModelProfile>());

            services.AddScoped<INoteImageRepository, NoteImageRepository>();
            services.AddScoped<INoteItemRepository, NoteItemRepository>();
            services.AddScoped<INoteListRepository, NoteListRepository>();
            services.AddScoped<INoteTagLinkRepository, NoteTagLinkRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NoteList.Controller", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoteList.Controller v1"));
            }

            if (env.IsProduction())
            {
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
