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
    public interface ISchemeDbContext : IEfCoreDbContext
    {
        DbSet<Inbound_Mimo_Customer> Inbound_Mimo_Customer { get; }

    }
}
