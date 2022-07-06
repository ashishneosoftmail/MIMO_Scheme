using Microsoft.AspNetCore.Cors;
using Microsoft.OpenApi.Models;
using OldMutual.Scheme.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.AspNetCore.ExceptionHandling;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Autofac;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.SqlServer;
using Volo.Abp.Modularity;
using Volo.Abp.Uow;

namespace OldMutual.Scheme.Host
{
    [DependsOn(
       typeof(AbpAutofacModule),
      typeof(AbpAspNetCoreMvcModule),
      typeof(AbpEntityFrameworkCoreSqlServerModule),
      typeof(SchemeApplicationModule),
      typeof(SchemeHttpApiModule),
      typeof(SchemeEntityFrameworkCoreModule)
      )]
    public class SchemeServiceHostModule : AbpModule
    {
        private const string CorsPolicyName = "OldMutualScheme";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddSwaggerGen(
                options =>
                {
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Scheme Service API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                }
            );

            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<AbpUnitOfWorkDefaultOptions>(options =>
            {
                options.TransactionBehavior = UnitOfWorkTransactionBehavior.Enabled;
            });

            context.Services.Configure<AbpExceptionHandlingOptions>(options =>
            {
                options.SendExceptionsDetailsToClients = true;
                options.SendStackTraceToClients = true;
            });

            context.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .WithOrigins(
                            configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .Select(o => o.Trim().RemovePostFix("/"))
                                .ToArray()
                        )
                        .WithAbpExposedHeaders()
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                });
            });

        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseAuthentication();

            //app.UseAuthorization();
            app.UseAbpClaimsMap();
            app.UseCors();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Scheme Service API");

            });
            app.UseUnitOfWork();
            app.UseConfiguredEndpoints();

        }
    }
}
