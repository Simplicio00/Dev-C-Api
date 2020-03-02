using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Senai.Inlock.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            //   services.AddSwaggerGen(c =>
            //   {
            //         c.SwaggerDoc("v1", new OpenApiInfo { Title = "Senai.Inlock.WebApi", Version = "v1" });
            //      var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //      var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //      c.IncludeXmlComments(xmlPath);
            //   });

            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.
               AddAuthentication(options => { options.DefaultAuthenticateScheme = "JwtBearer"; options.DefaultChallengeScheme = "JwtBearer"; })
               .AddJwtBearer("JwtBearer", options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("c2ef68458373939242f03e2ddce21091")),
                       ClockSkew = TimeSpan.FromMinutes(30),
                       ValidIssuer = "Senai.Inlock.WebApi",
                       ValidAudience = "Senai.Inlock.WebApi"
                   };
               });
            
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

           // app.UseSwagger();
            //app.UseSwaggerUI(c =>
           // {
           //     c.SwaggerEndpoint("/swagger/v1/swagger.json", "Senai.Inlock.WebApi");
           // });

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
