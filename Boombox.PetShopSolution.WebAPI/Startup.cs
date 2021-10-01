using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boombox.PetShopSolution.Core.IServices;
using Boombox.PetShopSolution.Domain.IRepositories;
using Boombox.PetShopSolution.Domain.Services;
using Boombox.PetShopSolution.EFSQL;
using Boombox.PetShopSolution.EFSQL.Repositories;
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
using AspNetCore.Authentication.JwtBearer.Extension;
namespace Boombox.PetShopSolution.WebAPI
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
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Boombox.PetShopSolution.WebAPI", Version = "v1"});
            });

            var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            
            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddScoped<IPetColorRepository, PetColorRepository>();
            services.AddScoped<IPetColorService, PetColorService>();
            services.AddScoped<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<IPetOwnerRepository, PetOwnerRepository>();
            services.AddScoped<IPetOwnerService, PetOwnerService>();


            
            
            services.AddTransient<IDatabaseInitialise, DatabaseInitialise>();


            services.AddDbContext<PetShopSolutionContext>(
                opt =>
                {
                    opt
                        .UseLoggerFactory(loggerFactory)
                        .UseSqlite("Data Source=PetShop.db");
                }, ServiceLifetime.Transient);
            
            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
        //     Byte[] secretBytes = new byte[40];
        //     Random rand = new Random();
        //     rand.NextBytes(secretBytes);
        //     //Add JWT authentication
        //     services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        //     {
        //         options.TokenValidationParameters = new TokenValidationParameters()
        //         {
        //             ValidateAudience = false,
        //             //ValidAudience = "CoMetaApiClient",
        //             ValidateIssuer = false,
        //             //ValidIssuer = "CoMetaApi",
        //             ValidateIssuerSigningKey = true,
        //             IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
        //             ValidateLifetime = true, //validate the expiration and not before values in the token
        //             ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
        //         };
        //     });
        //
      }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(
                    c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Boombox.PetShopSolution.WebAPI v1"));

                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var ctx = scope.ServiceProvider.GetService<PetShopSolutionContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();
                    var dbInitialiazer = services.GetService<IDatabaseInitialise>();
                    dbInitialiazer.seedDatabase(ctx);
                }
                
            }

           // app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}