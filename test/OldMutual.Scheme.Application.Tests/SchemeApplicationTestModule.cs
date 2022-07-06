using Volo.Abp.Modularity;

namespace OldMutual.Scheme;

[DependsOn(
    typeof(SchemeApplicationModule),
    typeof(SchemeDomainTestModule)
    )]
public class SchemeApplicationTestModule : AbpModule
{

}
