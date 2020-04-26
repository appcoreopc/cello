using Celo.Data.InMemory;
using Celo.Service.RandomUser.Service;
using Celo.Service.RandomUser.Validations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Celo.Service.RandomUser
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
            services.AddScoped(typeof(ICreateUserService), typeof(CreateUserService));
            services.AddScoped(typeof(IQueryValidator), typeof(QueryValidator));
            services.AddScoped(typeof(IUserDataProvider), typeof(UserDataProvider));
            services.AddScoped(typeof(IUserService), typeof(RandomUserService));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddXmlDataContractSerializerFormatters();
            services.AddDbContext<UserDataContext>(opt => opt.UseInMemoryDatabase());
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

            app.UseMvc();
        }
    }
}
