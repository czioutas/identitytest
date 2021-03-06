
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace identityissue
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
            // IF YOU WANNA USE PGSQL GO TO PROGRAM AND UNCOMMENT DROP AND UPDATE
            // var DbConnectionString = Configuration.GetConnectionString("DataPgsql");
            // Console.WriteLine($"DB: {DbConnectionString}");
            // services.AddDbContext<DbContext>(
            //     options =>
            //     {
            //         options.EnableSensitiveDataLogging();
            //         options.UseNpgsql(DbConnectionString);
            //     }
            // );

            services.AddDbContext<DbContext>(
                options =>
                {
                    options.EnableSensitiveDataLogging();
                    options.UseInMemoryDatabase(databaseName: "issue");
                }
            );

            services.AddIdentity<ApplicationUserEntity, ApplicationRoleEntity>(options =>
            {
                options.User.RequireUniqueEmail = true;
                // options.Password.RequireUppercase = false;
            })
            .AddRoleManager<RoleManager<ApplicationRoleEntity>>()
            .AddEntityFrameworkStores<DbContext>()
            .AddDefaultTokenProviders();

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
