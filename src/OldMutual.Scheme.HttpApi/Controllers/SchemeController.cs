using Microsoft.AspNetCore.Mvc;
using OldMutual.Scheme.Localization;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Uow;

namespace OldMutual.Scheme.Controllers;

/* Inherit your controllers from this class.
 */
//[Area("Schema")]
[Route("api/Schema/CustomerSchema")]
[IgnoreAntiforgeryToken]
public  class SchemeController : AbpControllerBase, ISchemeAppService

{
    private readonly ISchemeAppService _ISchemeAppService;

   
    public SchemeController (ISchemeAppService SchemeAppService) 
    {
        _ISchemeAppService = SchemeAppService;   
    }


    [HttpPost]
    [UnitOfWork]
    public async Task<Inbound_Mimo_CustomerDto> CreateAsync(CreateInbound_Mimo_CustomerDto createInbound_Mimo_CustomerDto)
    {
        return await _ISchemeAppService.CreateAsync(createInbound_Mimo_CustomerDto);
    }
}
