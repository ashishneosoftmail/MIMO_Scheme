using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace OldMutual.Scheme.Data;

/* This is used if database provider does't define
 * ISchemeDbSchemaMigrator implementation.
 */
public class NullSchemeDbSchemaMigrator : ISchemeDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
