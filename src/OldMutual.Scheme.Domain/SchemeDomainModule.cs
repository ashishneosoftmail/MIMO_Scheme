using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OldMutual.Scheme.MultiTenancy;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp.VirtualFileSystem;

namespace OldMutual.Scheme;

[DependsOn(
    typeof(AbpEntityFrameworkCoreModule)
    //typeof(SchemeDomainSharedModule),
    //typeof(AbpAuditLoggingDomainModule),
    //typeof(AbpBackgroundJobsDomainModule),
    //typeof(AbpFeatureManagementDomainModule),
    //typeof(AbpIdentityDomainModule),
    //typeof(AbpPermissionManagementDomainIdentityModule),
    //typeof(AbpIdentityServerDomainModule),
    //typeof(AbpPermissionManagementDomainIdentityServerModule),
    //typeof(AbpSettingManagementDomainModule),
    //typeof(AbpTenantManagementDomainModule),
    //typeof(AbpEmailingModule)
)]
public class SchemeDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SchemeDomainModule>();
        });

#if DEBUG
        context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }
}
