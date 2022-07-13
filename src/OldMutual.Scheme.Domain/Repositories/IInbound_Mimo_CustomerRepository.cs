using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OldMutual.Scheme.Repositories
{
    public interface IInbound_Mimo_CustomerRepository : IRepository<Inbound_Mimo_Customer, Guid>
    {
        Task ValidateInboundAsync(string type);

        Task<Tuple<bool>> InsertSchemeAsync(DataTable type);

        Task<Tuple<bool>> InsertSchemeAsync_Bulk(List<Inbound_Mimo_Customer> input);

        Task<Tuple<string, string, int>> InsertSchemeAsync_ADO(DataTable dt);
    }
}

