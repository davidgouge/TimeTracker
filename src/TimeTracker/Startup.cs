using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using TimeTracker.Model;

namespace TimeTracker
{
    public class Startup
    {
        public static IConfigurationRoot Config;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddJsonFile("config.json");

            Config = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<TimeTrackerContext>(builder => builder.UseSqlServer(Config["Data:ConnectionString"]));// .AddDbContext<TimeTrackerContext>();

            services.AddTransient<DataSeeder>();
        }
        
        public void Configure(IApplicationBuilder app, DataSeeder seeder)
        {
            app.UseStaticFiles();
            app.UseMvc(config => {
                config.MapRoute("Default", "{controller}/{action}/{id?}", new { controller = "Home", action = "Index" });
            });

            seeder.Seed();
        }
        
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
