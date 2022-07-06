using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace OldMutual.Scheme;

[DependsOn(
    typeof(SchemeDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(SchemeApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
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
