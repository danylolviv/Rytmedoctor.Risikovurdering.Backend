using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Repositories;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI
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
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1",
          new OpenApiInfo
          {
            Title =
              "DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI",
            Version = "v1"
          });
      });
      
      var loggerFactory = LoggerFactory.Create(builder =>
      {
        builder.AddConsole();
      });
      
      services.AddDbContext<MainDbContext>(
        opt =>
        {
          opt
            .UseLoggerFactory(loggerFactory)
            .UseSqlite("Data Source=SurveyForm.db");
        }, ServiceLifetime.Transient);
      
      services.AddScoped<IQuestionService, QuestionService>();
      services.AddScoped<IQuestionRepository, QuestionRepository>();
      
      
      // Todo Create corse
      
      
    }
    
    

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, MainDbContext ctx)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
          "DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI v1"));
        DbSeeding seeder = new DbSeeding(ctx);
        seeder.SeedDevelopment();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}