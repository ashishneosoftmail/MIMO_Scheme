using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OldMutual.Scheme.Localization;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace OldMutual.Scheme;

/* Inherit your application services from this class.
 */
public  class SchemeAppService : ApplicationService, ISchemeAppService
{
   private readonly Inbound_Mimo_Customer_Manager _inbound_Mimo_Customer_Manager;
   private readonly IRepository<Inbound_Mimo_Customer, Guid> _inbound_Mimo_CustomerRepository;

    public SchemeAppService(Inbound_Mimo_Customer_Manager inbound_Mimo_CustomerManager, IRepository<Inbound_Mimo_Customer, Guid> inbound_Mimo_CustomerRepository)
    {
        _inbound_Mimo_Customer_Manager = inbound_Mimo_CustomerManager;
        _inbound_Mimo_CustomerRepository = inbound_Mimo_CustomerRepository;
        ObjectMapperContext = typeof(SchemeApplicationModule);
    }

    public async Task<Inbound_Mimo_CustomerDto> CreateAsync(CreateInbound_Mimo_CustomerDto input)
    {
        var customerscheme = await _inbound_Mimo_Customer_Manager.CreateAsync(
                               input.schemeId 
                             , input.system
                             , input.systemCompanyId
                             , input.systemUniqueId
                             , input.customerGroupId
                             , input.primaryEmailAddress
                             , input.pinNumber
                             , input.currencyCode
                             , input.partyType
                             , input.primaryPhoneNumber
                             , input.addressDefaultRoles
                             , input.addressCountryCode
                             , input.billGroupCombinedCollection
                             , input.brokerCode
                             , input.isBillGroup
                             , input.billGroupNo
                             , input.billGroupName
                             , input.brokerCombinedCollection
                             , input.customerBankAccountHolder
                             , input.customerBankAccountNumber
                             , input.customerBankBranchCode
                             , input.customerBankName
                             , input.customerCellularAccountNumber
                             , input.customerExternalMethodOfPayment
                             , input.iBanNo
                             , input.addressDescription
            );

        return ObjectMapper.Map<Inbound_Mimo_Customer, Inbound_Mimo_CustomerDto>(customerscheme);
    }
}
