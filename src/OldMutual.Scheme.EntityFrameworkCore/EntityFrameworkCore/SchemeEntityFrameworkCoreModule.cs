using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OldMutual.Scheme.EntityFrameworkCore.Repositories;
using OldMutual.Scheme.Scheme;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;


namespace OldMutual.Scheme.EntityFrameworkCore;

[DependsOn(
    typeof(SchemeDomainModule),
    typeof(AbpEntityFrameworkCoreSqlServerModule)   
    )]
public class SchemeEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<SchemeDbContext>(options =>
        {
            /* Remove "includeAllEntities: true" to create
             * default repositories only for aggregate roots */
            options.AddDefaultRepositories();
            options.AddRepository<Inbound_Mimo_Customer, Inbound_Mimo_CustomerRepository>();
           

        });

        //Configure<AbpDbContextOptions>(options =>
        //{
        //        /* The main point to change your DBMS.
        //         * See also SchemeMigrationsDbContextFactory for EF Core tooling. */
        //    options.UseSqlServer();
        //});
    }
}
