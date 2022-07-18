using learn.core1.domain;
using learn.core1.Repoisitory;
using learn.core1.service;
using learn.infra1.domain;
using learn.infra1.Repoisitory;
using learn.infra1.service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication13
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

            services.AddScoped<IDBContext, DbContext>();
            services.AddScoped<Icategoreyrepoisitory, categoreyrepoisitorycs>();
            services.AddScoped<Icourse_apirepository,course_apirepoisitory>();
            services.AddScoped<Iemp_apirepositiorycs, emp_apirepoisitory>();

            services.AddScoped<Icategoreyservice,categoreyservice>();
            services.AddScoped<Icourseservice, courserservice>();

            services.AddScoped<Iemp_service, emp_api_service>();

            services.AddScoped<IAuthentication, Authentication>();
            services.AddScoped<IAuthenticationservice, Authenticationservice>();


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }

            ).AddJwtBearer(y =>
            {
                y.RequireHttpsMetadata = false;
                y.SaveToken = true;
                y.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.ASCII.GetBytes("[SECRET Used To Sign And Verify Jwt Token,It can be any string]")),
                    ValidateIssuer=false,
                    ValidateAudience=false,

                };


            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
