using System.Threading.Tasks;

namespace OldMutual.Scheme.Data;

public interface ISchemeDbSchemaMigrator
{
    Task MigrateAsync();
}
