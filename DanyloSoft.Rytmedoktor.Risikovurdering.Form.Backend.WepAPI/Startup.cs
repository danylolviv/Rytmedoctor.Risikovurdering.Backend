using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Core.IServices;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.DataAccess.Repositories;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Domain.Services;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security;
using DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.Security.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
          Name = "Authorization",
          Type = SecuritySchemeType.ApiKey,
          Scheme = "Bearer",
          BearerFormat = "JWT",
          In = ParameterLocation.Header,
          Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
          {
            new OpenApiSecurityScheme
            {
              Reference = new OpenApiReference
              {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
              }
            },
            new string[] {}
          }
        });
      });

      services.AddAuthentication(authentificationOptions =>
        {
          authentificationOptions.DefaultAuthenticateScheme =
            JwtBearerDefaults.AuthenticationScheme;

          authentificationOptions.DefaultChallengeScheme =
            JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
          options.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
              new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Configuration["jwtConfig:secret"])),
            ValidateIssuer = true,
            ValidIssuer = Configuration["jwtConfig:issuer"],
            ValidateAudience = true,
            ValidAudience = Configuration["jwtConfig:audience"]
          };
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
      
      services.AddDbContext<AuthDbContext>(
        opt =>
        {
          opt
            .UseLoggerFactory(loggerFactory)
            .UseSqlite("Data Source=Security.db");
        }, ServiceLifetime.Transient);
      
      services.AddCors(option =>
      {
        option.AddPolicy("rytmedoctor-backend-policy",
          builder =>
          {
            builder
              .AllowAnyHeader()
              .AllowAnyMethod()
              .WithOrigins("http://localhost:4200");
          });
      });
      
      //Main Setup
      services.AddScoped<IQuestionService, QuestionService>();
      services.AddScoped<IQuestionRepository, QuestionRepository>();
      services.AddScoped<ISecurityService, SecurityService>();
      
      // Security setup
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<ISecurityService, SecurityService>();
      services.AddScoped<IAuthUserService, AuthUserService>();
      
    }
    
    

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(
      IApplicationBuilder app, 
      IWebHostEnvironment env, 
      MainDbContext ctx,
      AuthDbContext authCtx
      )
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
          "DanyloSoft.Rytmedoktor.Risikovurdering.Form.Backend.WepAPI v1"));
        
        // We need this for one thing only and it is enough to cal the method from the constructor.
        new DbSeeding(ctx);
        new AuthDbSeeding(authCtx);
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();

      app.UseAuthorization();
      
      app.UseCors("rytmedoctor-backend-policy");

      app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
  }
}