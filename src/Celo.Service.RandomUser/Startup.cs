using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Celo.Data.InMemory;
using Celo.Service.RandomUser.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Celo.Service.RandomUser
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
            services.AddScoped(typeof(UserDataProvider), typeof(UserDataProvider));
            services.AddScoped(typeof(IUserDataProvider), typeof(UserDataProvider));
            services.AddScoped(typeof(IUserService), typeof(RandomUserService));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<UserDataContext>(opt => opt.UseInMemoryDatabase());
 
            // services.AddDbContext<UserDataContext>(
            //         options => options.UseMemoryCache();
            // );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
            
            //app.UseHttpsRedirection();
            app.UseMvc();
            //app.UseMvcWithDefaultRoute();
        }
    }
}
