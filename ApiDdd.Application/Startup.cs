using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using System.Reflection;
using ApiDdd.Domain.Interfaces;
using ApiDdd.Service.Services;
using ApiDdd.Infra.Data.Repository;
using System.Web.Http;

namespace ApiDdd.Application
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
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProdutoService, ProdutoService>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddAutoMapper(Assembly.GetAssembly(typeof(AutoMapperConfig)));
            //services.AddAutoMapper();

            services.AddMvc();

           services.AddSwaggerGen(c =>
           {
               c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey" });
               c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                    { "Bearer", Enumerable.Empty<string>() },
               });


               c.SwaggerDoc("v1",
                   new Info
                   {
                       Title = "ApiDdd",
                       Version = "v1",
                       Description = "API REST",
                   });

               string caminhoAplicacao =
                   PlatformServices.Default.Application.ApplicationBasePath;
               string nomeAplicacao =
                   PlatformServices.Default.Application.ApplicationName;
               string caminhoXmlDoc =
                   Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

               c.IncludeXmlComments(caminhoXmlDoc);
           });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "ApiDdd");
            });
        }
    }
}
