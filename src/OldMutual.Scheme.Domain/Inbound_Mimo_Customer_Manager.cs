using OldMutual.Scheme.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace OldMutual.Scheme
{
    public class Inbound_Mimo_Customer_Manager : DomainService
    {
        private readonly IInbound_Mimo_CustomerRepository _IInbound_Mimo_CustomerRepository;

        public Inbound_Mimo_Customer_Manager(IInbound_Mimo_CustomerRepository iInbound_Mimo_CustomerRepository)
        {
            _IInbound_Mimo_CustomerRepository = iInbound_Mimo_CustomerRepository;
        }


        public async Task<Inbound_Mimo_Customer> CreateAsync(
              string schemeid
            , string system
            , string systemCompanyId
            , string systemUniqueId
            , string customerGroupId
            , string primaryEmailAddress
            , string pinNumber
            , string currencyCode
            , string partyType
            , string primaryPhoneNumber
            , string addressDefaultRoles
            , string addressCountryCode
            , bool billGroupCombinedCollection
            , string brokerCode
            , bool isBillGroup
            , string billGroupNo
            , string billGroupName
            , bool brokerCombinedCollection
            , string customerBankAccountHolder
            , string customerBankAccountNumber
            , string customerBankBranchCode
            , string customerBankName
            , string customerCellularAccountNumber
            , string customerExternalMethodOfPayment
            , string iBanNo
            , string addressDescription
            )
        {

            try
            {
                var objInbound = new Inbound_Mimo_Customer(
                       GuidGenerator.Create()
                        , schemeid
                        , system
                        , systemCompanyId
                        , systemUniqueId
                        , customerGroupId
                        , primaryEmailAddress
                        , pinNumber
                        , currencyCode
                        , partyType
                        , primaryPhoneNumber
                        , addressDefaultRoles
                        , addressCountryCode
                        , billGroupCombinedCollection
                        , brokerCode
                        , isBillGroup
                        , billGroupNo
                        , billGroupName
                        , brokerCombinedCollection
                        , customerBankAccountHolder
                        , customerBankAccountNumber
                        , customerBankBranchCode
                        , customerBankName
                        , customerCellularAccountNumber
                        , customerExternalMethodOfPayment
                        , iBanNo
                        , addressDescription

               );

                var oInbouound = await _IInbound_Mimo_CustomerRepository.InsertAsync(objInbound, autoSave: true);
                //await _InboundRepository.ValidateInboundAsync(objInbound.System);
                return oInbouound;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
