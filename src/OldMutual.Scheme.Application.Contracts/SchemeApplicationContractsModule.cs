using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.VirtualFileSystem;

namespace OldMutual.Scheme;

[DependsOn(
    typeof(SchemeDomainSharedModule),
    typeof(AbpObjectExtendingModule)
)]
public class SchemeApplicationContractsModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<SchemeApplicationContractsModule>();
        });
    }
}
