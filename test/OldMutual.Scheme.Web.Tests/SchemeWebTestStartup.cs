using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp;

namespace OldMutual.Scheme;

public class SchemeWebTestStartup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplication<SchemeWebTestModule>();
    }

    public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
    {
        app.InitializeApplication();
    }
}
