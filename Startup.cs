using API_Campeones.ContextBD;
using API_Campeones.Repository;
using API_Campeones.Repository.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

namespace API_Campeones
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            services.AddDbContext<CampeonesContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DEV"));
            });

            services.AddScoped<ICampeonesRepository, CampeonesRepository>();
            services.AddScoped<IDificultadesRepository, DificultadesRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IJWTRepository, JWTRepository>();

            services.AddControllersWithViews();

            //Agregando swagger
            services.AddSwaggerGen( s =>
            {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "API CAMPEONES",
                    Version = "v1",
                });
                s.CustomSchemaIds( s => s.FullName );
            });

            //AutoMapper
            services.AddAutoMapper(typeof(CampeonesRepository));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                    opt =>
                    {
                        opt.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("My jwt secret ACCESS TO API CAMPEONES")),
                            ValidateAudience = false,
                            ValidateIssuer = false,
                        };
                    }
                );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();

            app.UseCors("AllowAllOrigins");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/Swagger/v1/swagger.json", "API CAMPEONES");
            });
        }
    }
}
