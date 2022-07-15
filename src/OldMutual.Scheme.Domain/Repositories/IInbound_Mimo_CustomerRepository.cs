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

       // Task<Tuple<bool>> InsertSchemeAsync(DataTable type);

        Task<Tuple<bool, int>> InsertSchemeAsync_Bulk(List<Inbound_Mimo_Customer> input);


        //ado-bulk insert
        Task<Tuple<string, int, string, string>> InsertSchemeAsync_ADO(DataTable dt);
    }
}

