using OldMutual.Scheme.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace OldMutual.Scheme;

[DependsOn(
    typeof(SchemeEntityFrameworkCoreTestModule)
    )]
public class SchemeDomainTestModule : AbpModule
{

}
