using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arcane.AspNetCore.Samples.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.ArcaneInMemory;
using Microsoft.Extensions.Logging;

namespace Arcane.AspNetCore.Samples
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            //services.AddArcaneWithInMemoryData();
            services.AddArcaneWithEntityFramework<AuthorsDbContext>(
                options => options.UseSqlite(new SqliteConnectionStringBuilder
                {
                    DataSource = "Test.db"
                }.ToString())
            );
            //services.AddArcaneWithMongoDB("mongodb://localhost/arcanesamples");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider provider, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            using (var context = provider.GetService<AuthorsDbContext>())
            {
                context.Database.EnsureCreated();
            }

            app.UseMvc();
        }
    }
}
