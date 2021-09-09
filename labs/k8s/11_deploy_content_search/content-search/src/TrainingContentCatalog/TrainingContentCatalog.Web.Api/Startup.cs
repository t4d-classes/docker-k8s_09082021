using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using TrainingContentCatalog.Common;
using TrainingContentCatalog.DataAccess;
using TrainingContentCatalog.DataAccess.Services;
using TrainingContentCatalog.Services;

namespace TrainingContentCatalog.Web.Api
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddScoped<SearchCache>(Span =>
        new SearchCache(
          Configuration.GetConnectionString("TrainingCatalogCacheServer")
        ));

      services.AddScoped<TrainingCatalogDbContext>(sp =>
        new TrainingCatalogDbContext(
          Configuration.GetConnectionString("TrainingCatalogDbServer"),
          Configuration["DatabaseName"]
        ));

      services.AddScoped<CatalogItems>();
      services.AddScoped<CatalogLookups>();

      services.AddScoped<ITrainingContentSearch, TrainingContentSearchDatabase>();
      services.AddScoped<IContentManager, ContentManagerDatabase>();

      if (Configuration["ASPNETCORE_ENVIRONMENT"] == "Development")
      {
        services.AddCors(options =>
        {
          options.AddDefaultPolicy(
            builder =>
            {
              builder
                .WithOrigins("https://localhost:5011", "http://localhost:5010")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });
      }

      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "TrainingContentCatalog.Web.Api", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TrainingContentCatalog.Web.Api v1"));
      }

      // app.UseHttpsRedirection();

      app.UseCors();
      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
