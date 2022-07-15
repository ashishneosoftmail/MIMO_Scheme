using Volo.Abp.AspNetCore.Mvc;

namespace OldMutual.Scheme.Host
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<SchemeServiceHostModule>();
            services.AddControllersWithViews();
            services.AddSingleton(_configuration);

            services.AddAbpApiVersioning(options =>
            {
                // Show neutral/versionless APIs.
                options.UseApiBehavior = false;

                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
            });
           
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }

    }
}
