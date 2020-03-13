using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace Gufi.Senai.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo{ Title = "Gufi.Senai.WebApi", Version = "v1",Description="Projeto api Gufi" });
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    c.IncludeXmlComments(xmlPath);
                });





            services
                .AddMvc()
                 .AddJsonOptions(options =>
                 {
                     options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 })
                 .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);


            services.
             AddAuthentication(op => {
                 op.DefaultAuthenticateScheme = "JwtBearer";
                 op.DefaultChallengeScheme = "JwtBearer";
             }).
                AddJwtBearer("JwtBearer", op =>
                 {
                     op.TokenValidationParameters = new TokenValidationParameters
                     {
                         ValidateIssuer = true,
                         ValidateAudience = true,
                         ValidateLifetime = true,
                         IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("0d13199c64d04f59d9e56a68f1844d09")),
                         ClockSkew = TimeSpan.FromMinutes(30),
                         ValidIssuer = "Gufi.Senai.WebApi",
                         ValidAudience = "Gufi.Senai.WebApi"
                     };
                 });


        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gufi.Senai.WebApi");
            });



            app.UseMvc();
        }
    }
}
