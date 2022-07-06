using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OldMutual.Scheme
{
    public  interface ISchemeAppService : IApplicationService
    {
        Task<Inbound_Mimo_CustomerDto> CreateAsync(CreateInbound_Mimo_CustomerDto input);

    }
  
    public interface IInbound_Mimo_CustomerRepository : IRepository<Inbound_Mimo_Customer, Guid>
    {
        Task ValidateInbound(string type);
    }

}
