using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OldMutual.Scheme
{
    public  interface ISchemeAppService : IApplicationService
    {
        Task<Inbound_Mimo_CustomerDto> CreateAsync(CreateInbound_Mimo_CustomerDto input);

        Task<ListResultDto<Inbound_Mimo_CustomerDto>> GetListAsync();

        Task<Inbound_Mimo_CustomerDto> CreateAsync_Bulk(List<Inbound_Scheme_BillGroups> input);

        Task<Tuple<bool,string>> CreateAsync_A(List<Inbound_Scheme_BillGroups> input);

        Task<Tuple<bool>> InsertSchemeAsync_Bulk(List<Inbound_Scheme_BillGroups> input);

        Task<SchemeResponse> InsertSchemeAsync_ADO(List<Inbound_Scheme_BillGroups> input);
    }
  
    public interface IInbound_Mimo_CustomerRepository : IRepository<Inbound_Mimo_Customer, Guid>
    {
        Task ValidateInbound(string type);
    }

   

}
