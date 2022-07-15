using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;


namespace OldMutual.Scheme;

[DependsOn(
    typeof(SchemeDomainModule),
    typeof(SchemeApplicationContractsModule)   
    )]
public class SchemeApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<SchemeApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddProfile<SchemeApplicationAutoMapperProfile>(validate: false);
            options.AddMaps<SchemeApplicationModule>();
        });
    }
}
