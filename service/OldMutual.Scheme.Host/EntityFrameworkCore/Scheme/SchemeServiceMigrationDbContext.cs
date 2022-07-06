using Microsoft.EntityFrameworkCore;
using OldMutual.Scheme.Scheme;
using Volo.Abp.EntityFrameworkCore;

namespace OldMutual.Scheme.Host.EntityFrameworkCore.Scheme
{
    public class SchemeServiceMigrationDbContext : AbpDbContext<SchemeServiceMigrationDbContext>
    {
        public SchemeServiceMigrationDbContext(
           DbContextOptions<SchemeServiceMigrationDbContext> options
           ) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureSchemeManagement();
        }
    }
}
