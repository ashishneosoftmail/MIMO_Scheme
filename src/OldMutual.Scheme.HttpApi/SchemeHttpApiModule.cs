using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using OldMutual.Scheme.Localization;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace OldMutual.Scheme;

[DependsOn(
          typeof(SchemeApplicationContractsModule),
          typeof(AbpAspNetCoreMvcModule))]
public class SchemeHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(SchemeHttpApiModule).Assembly);
        });
    }
}
