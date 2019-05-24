using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiPerson.BusinessLogic.Managers;
using ApiPerson.DataAccess;
using ApiPerson.DataAccess.Repositories;
using ApiPerson.Entities.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiPerson
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddScoped<IPersonManager, PersonManager>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddEntityFrameworkSqlite().AddDbContext<PersonContext>();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            using (var client = new PersonContext())
            {
                client.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
