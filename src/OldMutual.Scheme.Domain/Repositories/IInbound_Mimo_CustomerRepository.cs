using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace OldMutual.Scheme.Repositories
{
    public interface IInbound_Mimo_CustomerRepository : IRepository<Inbound_Mimo_Customer, Guid>
    {
        Task ValidateInboundAsync(string type);
    }
}

