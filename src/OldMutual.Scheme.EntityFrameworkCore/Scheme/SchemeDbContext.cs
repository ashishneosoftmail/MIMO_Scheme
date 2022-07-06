using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace OldMutual.Scheme.Scheme
{
    [ConnectionStringName("connectionString")]
    public class SchemeDbContext : AbpDbContext<SchemeDbContext>, ISchemeDbContext
    {
        public static string TablePrefix { get; set; } = SchemeConsts.DbTablePrefix;

        public static string Schema { get; set; } = SchemeConsts.DbSchema;

        public DbSet<Inbound_Mimo_Customer> Inbound_Mimo_Customer { get; set; }

        public SchemeDbContext(DbContextOptions<SchemeDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureSchemeManagement(options =>
            {
                options.TablePrefix = TablePrefix;
                options.Schema = Schema;
            });
        }
    }
}
