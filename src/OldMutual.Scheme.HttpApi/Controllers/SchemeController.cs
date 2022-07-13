using Microsoft.AspNetCore.Mvc;
using OldMutual.Scheme.Localization;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Uow;

namespace OldMutual.Scheme.Controllers;

/* Inherit your controllers from this class.
 */
//[Area("Schema")]

[IgnoreAntiforgeryToken]
public class SchemeController : AbpControllerBase, ISchemeAppService

{
    private readonly ISchemeAppService _ISchemeAppService;

    SchemeResponse schemeResponse;
    public SchemeController(ISchemeAppService SchemeAppService)
    {
        _ISchemeAppService = SchemeAppService;
    }


    [HttpPost]
    [UnitOfWork]
    [Route("api/Scheme/CustomerScheme_Test")]
    public async Task<Inbound_Mimo_CustomerDto> CreateAsync(CreateInbound_Mimo_CustomerDto createInbound_Mimo_CustomerDto)
    {
        return await _ISchemeAppService.CreateAsync(createInbound_Mimo_CustomerDto);
    }

    [HttpPost]
    [UnitOfWork]
    [Route("api/Scheme/CreateAsync_Bulk")]
    public async Task<Inbound_Mimo_CustomerDto> CreateAsync_Bulk(List<Inbound_Scheme_BillGroups> inbound_Scheme_BillGroups)
    {
        return await _ISchemeAppService.CreateAsync_Bulk(inbound_Scheme_BillGroups);
    }

    [HttpPost]
    [UnitOfWork]
    [Route("api/Scheme/CustomerScheme")]
    public async Task<Tuple<bool, string>> CreateAsync_A(List<Inbound_Scheme_BillGroups> inbound_Scheme_BillGroups)
    {
        bool result = false;
        string msg = string.Empty;

        var tuple = await _ISchemeAppService.CreateAsync_A(inbound_Scheme_BillGroups);

        result = tuple.Item1;
        msg = tuple.Item2;

        return new Tuple<bool, string>(result, msg);
    }

    [HttpPost]
    [UnitOfWork]
    [Route("api/Scheme/InsertSchemeAsync_Bulk")]
    public async Task<Tuple<bool>> InsertSchemeAsync_Bulk(List<Inbound_Scheme_BillGroups> inbound_Scheme_BillGroups)
    {
        return await _ISchemeAppService.InsertSchemeAsync_Bulk(inbound_Scheme_BillGroups);
    }

    [HttpPost]
    [UnitOfWork]
    [Route("api/Scheme/InsertSchemeAsync_ADO")]
    public async Task<SchemeResponse> InsertSchemeAsync_ADO(List<Inbound_Scheme_BillGroups> inbound_Scheme_BillGroups)
    {
        schemeResponse = new SchemeResponse();
        schemeResponse = await _ISchemeAppService.InsertSchemeAsync_ADO(inbound_Scheme_BillGroups);
        
        return schemeResponse;
    }


    [HttpGet]
    [Route("all")]
    public Task<ListResultDto<Inbound_Mimo_CustomerDto>> GetListAsync()
    {
        return _ISchemeAppService.GetListAsync();
    }
}
