using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OldMutual.Scheme.Localization;
using OldMutual.Scheme.Validations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using OldMutual.Scheme.Responses;

namespace OldMutual.Scheme;

/* Inherit your application services from this class.
 */
public class SchemeAppService : ApplicationService, ISchemeAppService
{
    private readonly Inbound_Mimo_Customer_Manager _inbound_Mimo_Customer_Manager;
    private readonly IRepository<Inbound_Mimo_Customer, Guid> _inbound_Mimo_CustomerRepository;

    SuccessResponse schemeResponse;
    BadRequestResponse badRequestResponse;
    BadRequestErrorsResponse badRequestErrorsResponse;

    public SchemeAppService(Inbound_Mimo_Customer_Manager inbound_Mimo_CustomerManager, IRepository<Inbound_Mimo_Customer, Guid> inbound_Mimo_CustomerRepository)
      {
        _inbound_Mimo_Customer_Manager = inbound_Mimo_CustomerManager;
        _inbound_Mimo_CustomerRepository = inbound_Mimo_CustomerRepository;
        ObjectMapperContext = typeof(SchemeApplicationModule);
    }

    //public async Task<Inbound_Mimo_CustomerDto> CreateAsync(CreateInbound_Mimo_CustomerDto input)
    //{
    //    var customerscheme = await _inbound_Mimo_Customer_Manager.CreateAsync(
    //                           input.schemeId
    //                         , input.system
    //                         , input.systemCompanyId
    //                         , input.systemUniqueId
    //                         , input.customerGroupId
    //                         , input.primaryEmailAddress
    //                         , input.pinNumber
    //                         , input.currencyCode
    //                         , input.partyType
    //                         , input.primaryPhoneNumber
    //                         , input.addressDefaultRoles
    //                         , input.addressCountryCode
    //                         , input.billGroupCombinedCollection
    //                         , input.brokerCode
    //                         , input.isBillGroup
    //                         , input.billGroupNo
    //                         , input.billGroupName
    //                         , input.brokerCombinedCollection
    //                         , input.customerBankAccountHolder
    //                         , input.customerBankAccountNumber
    //                         , input.customerBankBranchCode
    //                         , input.customerBankName
    //                         , input.customerCellularAccountNumber
    //                         , input.customerExternalMethodOfPayment
    //                         , input.iBanNo
    //                         , input.addressDescription
    //        );

    //    return ObjectMapper.Map<Inbound_Mimo_Customer, Inbound_Mimo_CustomerDto>(customerscheme);
    //}

    //public async Task<Inbound_Mimo_CustomerDto> CreateAsync_Bulk(List<Inbound_Scheme_BillGroups> input)
    //{
    //    List<Inbound_Mimo_Customer> lstInbound_Mimo_Customer = new List<Inbound_Mimo_Customer>();

    //    for (int i = 0; i < input.Count; i++)
    //    {
    //        foreach (var obj in input[i].billGroups)
    //        {
    //            Inbound_Mimo_Customer inbound_Mimo_Customer = new Inbound_Mimo_Customer();
    //            //inbound_Mimo_Customer.Id = GuidGenerator.Create();
    //            inbound_Mimo_Customer.system = input[i].system;
    //            inbound_Mimo_Customer.schemeId = input[i].schemeId;
    //            inbound_Mimo_Customer.systemCompanyId = input[i].systemCompanyId;
    //            inbound_Mimo_Customer.systemUniqueId = input[i].systemUniqueId;
    //            inbound_Mimo_Customer.customerGroupId = obj.customerGroupId;
    //            inbound_Mimo_Customer.primaryEmailAddress = input[i].primaryEmailAddress;
    //            inbound_Mimo_Customer.pinNumber = input[i].pinNumber;
    //            inbound_Mimo_Customer.currencyCode = input[i].currencyCode;
    //            inbound_Mimo_Customer.partyType = input[i].partyType;
    //            inbound_Mimo_Customer.primaryPhoneNumber = input[i].primaryPhoneNumber;
    //            inbound_Mimo_Customer.pinNumber = input[i].pinNumber;
    //            inbound_Mimo_Customer.addressDefaultRoles = input[i].addressDefaultRoles;
    //            inbound_Mimo_Customer.addressCountryCode = input[i].addressCountryCode;
    //            inbound_Mimo_Customer.brokerCombinedCollection = input[i].brokerCombinedCollection;
    //            inbound_Mimo_Customer.brokerCode = input[i].brokerCode;
    //            inbound_Mimo_Customer.isBillGroup = obj.isBillGroup;
    //            inbound_Mimo_Customer.billGroupNo = obj.billGroupNo;
    //            inbound_Mimo_Customer.billGroupName = obj.billGroupName;
    //            inbound_Mimo_Customer.billGroupCombinedCollection = obj.billGroupCombinedCollection;
    //            inbound_Mimo_Customer.customerBankAccountHolder = obj.customerBankAccountHolder;
    //            inbound_Mimo_Customer.customerBankAccountNumber = obj.customerBankAccountNumber;
    //            inbound_Mimo_Customer.customerBankBranchCode = obj.customerBankBranchCode;
    //            inbound_Mimo_Customer.customerBankName = obj.customerBankName;
    //            inbound_Mimo_Customer.customerCellularAccountNumber = obj.customerCellularAccountNumber;
    //            inbound_Mimo_Customer.customerExternalMethodOfPayment = obj.customerExternalMethodOfPayment;
    //            inbound_Mimo_Customer.iBanNo = obj.iBanNo;
    //            inbound_Mimo_Customer.addressDescription = obj.addressDescription;

    //            lstInbound_Mimo_Customer.Add(inbound_Mimo_Customer);
    //        }
    //    }

    //    Inbound_Mimo_CustomerDto inbound_Mimo_CustomerDto = new Inbound_Mimo_CustomerDto();

    //    var customerscheme = await _inbound_Mimo_Customer_Manager.CreateAsync_Bulk(lstInbound_Mimo_Customer);

    //    return ObjectMapper.Map<Inbound_Mimo_Customer, Inbound_Mimo_CustomerDto>(customerscheme);
    //}

    //public async Task<Tuple<bool, string>> CreateAsync_A(List<Inbound_Scheme_BillGroups> input)
    //{
    //    bool result = false;
    //    string msg = string.Empty;

    //    List<Inbound_Mimo_Customer> lstInbound_Mimo_Customer = new List<Inbound_Mimo_Customer>();

    //    for (int i = 0; i < input.Count; i++)
    //    {
    //        foreach (var obj in input[i].billGroups)
    //        {
    //            Inbound_Mimo_Customer inbound_Mimo_Customer = new Inbound_Mimo_Customer();
    //            //inbound_Mimo_Customer.Id = GuidGenerator.Create();
    //            inbound_Mimo_Customer.system = input[i].system;
    //            inbound_Mimo_Customer.schemeId = input[i].schemeId;
    //            inbound_Mimo_Customer.systemCompanyId = input[i].systemCompanyId;
    //            inbound_Mimo_Customer.systemUniqueId = input[i].systemUniqueId;
    //            inbound_Mimo_Customer.customerGroupId = obj.customerGroupId;
    //            inbound_Mimo_Customer.primaryEmailAddress = input[i].primaryEmailAddress;
    //            inbound_Mimo_Customer.pinNumber = input[i].pinNumber;
    //            inbound_Mimo_Customer.currencyCode = input[i].currencyCode;
    //            inbound_Mimo_Customer.partyType = input[i].partyType;
    //            inbound_Mimo_Customer.primaryPhoneNumber = input[i].primaryPhoneNumber;
    //            inbound_Mimo_Customer.pinNumber = input[i].pinNumber;
    //            inbound_Mimo_Customer.addressDefaultRoles = input[i].addressDefaultRoles;
    //            inbound_Mimo_Customer.addressCountryCode = input[i].addressCountryCode;
    //            inbound_Mimo_Customer.brokerCombinedCollection = input[i].brokerCombinedCollection;
    //            inbound_Mimo_Customer.brokerCode = input[i].brokerCode;
    //            inbound_Mimo_Customer.isBillGroup = obj.isBillGroup;
    //            inbound_Mimo_Customer.billGroupNo = obj.billGroupNo;
    //            inbound_Mimo_Customer.billGroupName = obj.billGroupName;
    //            inbound_Mimo_Customer.billGroupCombinedCollection = obj.billGroupCombinedCollection;
    //            inbound_Mimo_Customer.customerBankAccountHolder = obj.customerBankAccountHolder;
    //            inbound_Mimo_Customer.customerBankAccountNumber = obj.customerBankAccountNumber;
    //            inbound_Mimo_Customer.customerBankBranchCode = obj.customerBankBranchCode;
    //            inbound_Mimo_Customer.customerBankName = obj.customerBankName;
    //            inbound_Mimo_Customer.customerCellularAccountNumber = obj.customerCellularAccountNumber;
    //            inbound_Mimo_Customer.customerExternalMethodOfPayment = obj.customerExternalMethodOfPayment;
    //            inbound_Mimo_Customer.iBanNo = obj.iBanNo;
    //            inbound_Mimo_Customer.addressDescription = obj.addressDescription;

    //            lstInbound_Mimo_Customer.Add(inbound_Mimo_Customer);
    //        }
    //    }

    //    for (int i = 0; i < lstInbound_Mimo_Customer.Count; i++)
    //    {
    //        var customerscheme = await _inbound_Mimo_Customer_Manager.CreateAsync(
    //                            lstInbound_Mimo_Customer[i].schemeId
    //                          , lstInbound_Mimo_Customer[i].system
    //                          , lstInbound_Mimo_Customer[i].systemCompanyId
    //                          , lstInbound_Mimo_Customer[i].systemUniqueId
    //                          , lstInbound_Mimo_Customer[i].customerGroupId
    //                          , lstInbound_Mimo_Customer[i].primaryEmailAddress
    //                          , lstInbound_Mimo_Customer[i].pinNumber
    //                          , lstInbound_Mimo_Customer[i].currencyCode
    //                          , lstInbound_Mimo_Customer[i].partyType
    //                          , lstInbound_Mimo_Customer[i].primaryPhoneNumber
    //                          , lstInbound_Mimo_Customer[i].addressDefaultRoles
    //                          , lstInbound_Mimo_Customer[i].addressCountryCode
    //                          , lstInbound_Mimo_Customer[i].billGroupCombinedCollection
    //                          , lstInbound_Mimo_Customer[i].brokerCode
    //                          , lstInbound_Mimo_Customer[i].isBillGroup
    //                          , lstInbound_Mimo_Customer[i].billGroupNo
    //                          , lstInbound_Mimo_Customer[i].billGroupName
    //                          , lstInbound_Mimo_Customer[i].brokerCombinedCollection
    //                          , lstInbound_Mimo_Customer[i].customerBankAccountHolder
    //                          , lstInbound_Mimo_Customer[i].customerBankAccountNumber
    //                          , lstInbound_Mimo_Customer[i].customerBankBranchCode
    //                          , lstInbound_Mimo_Customer[i].customerBankName
    //                          , lstInbound_Mimo_Customer[i].customerCellularAccountNumber
    //                          , lstInbound_Mimo_Customer[i].customerExternalMethodOfPayment
    //                          , lstInbound_Mimo_Customer[i].iBanNo
    //                          , lstInbound_Mimo_Customer[i].addressDescription
    //         );

    //        ObjectMapper.Map<Inbound_Mimo_Customer, Inbound_Mimo_CustomerDto>(customerscheme);
    //        result = true;
    //        msg = "Success";
    //    }

    //    return new Tuple<bool, string>(result, msg);

    //}



    public async Task<object> InsertSchemeAsync_Bulk(Inbound_Scheme_BillGroups input)
    {
        BaseResponse baseResponse = new();
        List<Inbound_Mimo_Customer> lstInbound_Mimo_Customer = new List<Inbound_Mimo_Customer>();

        foreach (var obj in input.billGroups)
        {
            Inbound_Mimo_Customer inbound_Mimo_Customer = new Inbound_Mimo_Customer(GuidGenerator.Create());
            inbound_Mimo_Customer.system = input.system;
            inbound_Mimo_Customer.schemeId = input.schemeId;
            inbound_Mimo_Customer.systemCompanyId = input.systemCompanyId;
            inbound_Mimo_Customer.systemUniqueId = input.systemUniqueId;
            inbound_Mimo_Customer.customerGroupId = obj.customerGroupId;
            inbound_Mimo_Customer.primaryEmailAddress = input.primaryEmailAddress;
            inbound_Mimo_Customer.pinNumber = input.pinNumber;
            inbound_Mimo_Customer.currencyCode = input.currencyCode;
            inbound_Mimo_Customer.partyType = input.partyType;
            inbound_Mimo_Customer.primaryPhoneNumber = input.primaryPhoneNumber;
            inbound_Mimo_Customer.pinNumber = input.pinNumber;
            inbound_Mimo_Customer.addressDefaultRoles = input.addressDefaultRoles;
            inbound_Mimo_Customer.addressCountryCode = input.addressCountryCode;
            inbound_Mimo_Customer.brokerCombinedCollection = input.brokerCombinedCollection;
            inbound_Mimo_Customer.brokerCode = input.brokerCode;
            inbound_Mimo_Customer.isBillGroup = obj.isBillGroup;
            inbound_Mimo_Customer.billGroupNo = obj.billGroupNo;
            inbound_Mimo_Customer.billGroupName = obj.billGroupName;
            inbound_Mimo_Customer.billGroupCombinedCollection = obj.billGroupCombinedCollection;
            inbound_Mimo_Customer.customerBankAccountHolder = obj.customerBankAccountHolder;
            inbound_Mimo_Customer.customerBankAccountNumber = obj.customerBankAccountNumber;
            inbound_Mimo_Customer.customerBankBranchCode = obj.customerBankBranchCode;
            inbound_Mimo_Customer.customerBankName = obj.customerBankName;
            inbound_Mimo_Customer.customerCellularAccountNumber = obj.customerCellularAccountNumber;
            inbound_Mimo_Customer.customerExternalMethodOfPayment = obj.customerExternalMethodOfPayment;
            inbound_Mimo_Customer.iBanNo = obj.iBanNo;
            inbound_Mimo_Customer.addressDescription = obj.addressDescription;          

            lstInbound_Mimo_Customer.Add(inbound_Mimo_Customer);
        }

        var tuple = await _inbound_Mimo_Customer_Manager.InsertSchemeAsync_Bulk(lstInbound_Mimo_Customer);
        baseResponse.isSuccess = tuple.Item1;
        baseResponse.status = tuple.Item2;       
        return baseResponse; 
        
    }


    //Bulk Insert using ADO
    public async Task<Tuple<string, int, string, string>> InsertSchemeAsync_ADO(List<Inbound_Scheme_BillGroups> input)
    {       
        List<Inbound_Mimo_Customer> lstInbound_Mimo_Customer = new List<Inbound_Mimo_Customer>();

        for (int i = 0; i < input.Count; i++)
        {
            foreach (var obj in input[i].billGroups)
            {
                Inbound_Mimo_Customer inbound_Mimo_Customer = new Inbound_Mimo_Customer();              
                inbound_Mimo_Customer.system = input[i].system;
                inbound_Mimo_Customer.schemeId = input[i].schemeId;
                inbound_Mimo_Customer.systemCompanyId = input[i].systemCompanyId;
                inbound_Mimo_Customer.systemUniqueId = input[i].systemUniqueId;
                inbound_Mimo_Customer.customerGroupId = obj.customerGroupId;
                inbound_Mimo_Customer.primaryEmailAddress = input[i].primaryEmailAddress;
                inbound_Mimo_Customer.pinNumber = input[i].pinNumber;
                inbound_Mimo_Customer.currencyCode = input[i].currencyCode;
                inbound_Mimo_Customer.partyType = input[i].partyType;
                inbound_Mimo_Customer.primaryPhoneNumber = input[i].primaryPhoneNumber;
                inbound_Mimo_Customer.pinNumber = input[i].pinNumber;
                inbound_Mimo_Customer.addressDefaultRoles = input[i].addressDefaultRoles;
                inbound_Mimo_Customer.addressCountryCode = input[i].addressCountryCode;
                inbound_Mimo_Customer.brokerCombinedCollection = input[i].brokerCombinedCollection;
                inbound_Mimo_Customer.brokerCode = input[i].brokerCode;
                inbound_Mimo_Customer.isBillGroup = obj.isBillGroup;
                inbound_Mimo_Customer.billGroupNo = obj.billGroupNo;
                inbound_Mimo_Customer.billGroupName = obj.billGroupName;
                inbound_Mimo_Customer.billGroupCombinedCollection = obj.billGroupCombinedCollection;
                inbound_Mimo_Customer.customerBankAccountHolder = obj.customerBankAccountHolder;
                inbound_Mimo_Customer.customerBankAccountNumber = obj.customerBankAccountNumber;
                inbound_Mimo_Customer.customerBankBranchCode = obj.customerBankBranchCode;
                inbound_Mimo_Customer.customerBankName = obj.customerBankName;
                inbound_Mimo_Customer.customerCellularAccountNumber = obj.customerCellularAccountNumber;
                inbound_Mimo_Customer.customerExternalMethodOfPayment = obj.customerExternalMethodOfPayment;
                inbound_Mimo_Customer.iBanNo = obj.iBanNo;
                inbound_Mimo_Customer.addressDescription = obj.addressDescription;

                lstInbound_Mimo_Customer.Add(inbound_Mimo_Customer);
            }
        }

        var tuple = await _inbound_Mimo_Customer_Manager.InsertSchemeAsync_ADO(lstInbound_Mimo_Customer);        

        return new Tuple<string, int, string, string>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);

    }


    public async Task<ListResultDto<Inbound_Mimo_CustomerDto>> GetListAsync()
    {
        var inbounds = await _inbound_Mimo_CustomerRepository.GetListAsync();

        var inboundList = ObjectMapper.Map<List<Inbound_Mimo_Customer>, List<Inbound_Mimo_CustomerDto>>(inbounds);

        return new ListResultDto<Inbound_Mimo_CustomerDto>(inboundList);
    }
}
