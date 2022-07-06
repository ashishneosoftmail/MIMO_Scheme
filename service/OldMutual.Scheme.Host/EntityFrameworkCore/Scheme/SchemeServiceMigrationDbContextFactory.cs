using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace OldMutual.Scheme.Host.EntityFrameworkCore.Scheme
{
    public class SchemeServiceMigrationDbContextFactory : IDesignTimeDbContextFactory<SchemeServiceMigrationDbContext>
    {
        public SchemeServiceMigrationDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<SchemeServiceMigrationDbContext>()
                .UseSqlServer(configuration.GetConnectionString("connectionString"));

            return new SchemeServiceMigrationDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
