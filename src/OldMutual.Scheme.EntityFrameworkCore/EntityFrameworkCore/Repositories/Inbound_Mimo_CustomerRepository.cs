using Microsoft.EntityFrameworkCore;
using OldMutual.Scheme.Repositories;
using OldMutual.Scheme.Scheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace OldMutual.Scheme.EntityFrameworkCore.Repositories
{
    public class Inbound_Mimo_CustomerRepository : EfCoreRepository<SchemeDbContext, Inbound_Mimo_Customer, Guid>, IInbound_Mimo_CustomerRepository
    {
        public Inbound_Mimo_CustomerRepository(IDbContextProvider<SchemeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public Task ValidateInbound(string type)
        {
            throw new NotImplementedException();
        }

        public async Task ValidateInboundAsync(string type)
        {
            var dbContext = await GetDbContextAsync();
            await dbContext.Database.ExecuteSqlRawAsync(
                $"dbo.InsertValidationType @type = '{type}'"
            );
        }
    }
}
