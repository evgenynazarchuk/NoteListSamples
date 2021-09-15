using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using NoteList.Domain.Configuration;
using NoteList.Domain.Models;
using NoteList.Services.Impl;
using NoteList.Services;

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
            services.AddScoped<DataWriteContext>();
            services.AddScoped<DataReadContext>();

            services.AddAutoMapper(config => config.AddProfile<ModelProfile>());

            services.AddTransient<NoteItemRepository>();
            services.AddTransient<IRepository<NoteImage>, Repository<NoteImage>>();
            services.AddTransient<IRepository<Domain.Models.NoteList>, Repository<Domain.Models.NoteList>>();
            services.AddTransient<TagRepository>();
            services.AddTransient<NoteTagLinkRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NoteList.WebApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoteList.WebApi v1"));
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
