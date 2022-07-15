
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OldMutual.Scheme.Localization;
using OldMutual.Scheme.Validations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Uow;

namespace OldMutual.Scheme.Controllers;

/* Inherit your controllers from this class.
 */
//[Area("Schema")]

[IgnoreAntiforgeryToken]
[ApiVersion("1.0", Deprecated = true)]
[Route("api/Scheme")]
public class SchemeController : AbpControllerBase, ISchemeAppService
{
    private readonly IConfiguration _Configuration;
    private readonly ISchemeAppService _ISchemeAppService;
    public readonly IHostingEnvironment _hEnvironment;

    SuccessResponse successResponse;
    BadRequestResponse badRequestResponse;
    BadRequestErrorsResponse badRequestErrorsResponse;
    UnprocessableResponse unprocessableResponse;

    public SchemeController(ISchemeAppService SchemeAppService, IConfiguration Configuration, IHostingEnvironment hEnvironment)
    {
        _ISchemeAppService = SchemeAppService;
        _Configuration = Configuration;
        _hEnvironment = hEnvironment;
    }

    #region "Scheme Insert"

    /// <summary>
    /// This API is used to insert the scheme based on specified request
    /// </summary>
    /// <param name="inbound_Scheme_BillGroups"></param>
    /// <returns></returns>
    [HttpPost]
    [UnitOfWork]
    public async Task<object> InsertSchemeAsync_Bulk(Inbound_Scheme_BillGroups inbound_Scheme_BillGroups)
    {
        object objResponse = null;
        successResponse = new();
        badRequestResponse = new();
        unprocessableResponse = new();
        badRequestErrorsResponse = new();
        badRequestResponse.error = new();
         
        try
        {
            var validator = new Inbound_Mimo_Customer_Validator();
            var results = validator.Validate(inbound_Scheme_BillGroups);
            if (results.Errors.Count > 0)
            {
                List<UnprocessableErrorsResponse> errors = new();
                foreach (var error in results.Errors)
                {
                    UnprocessableErrorsResponse unprocessableErrorsResponse = new();
                    unprocessableErrorsResponse.Status = 422;
                    unprocessableErrorsResponse.Code = error.ErrorCode;
                    unprocessableErrorsResponse.Message = error.ErrorMessage;
                    unprocessableErrorsResponse.Field = error.PropertyName;
                    errors.Add(unprocessableErrorsResponse);
                }

                unprocessableResponse.SchemeId = inbound_Scheme_BillGroups.schemeId;
                unprocessableResponse.error = errors;
                objResponse = unprocessableResponse;

                return objResponse;

            }
            else
            {
                BaseResponse response = (BaseResponse)await _ISchemeAppService.InsertSchemeAsync_Bulk(inbound_Scheme_BillGroups);

               
                if (response.isSuccess)
                {
                    successResponse.SchemeId = inbound_Scheme_BillGroups.schemeId;
                    successResponse.Message = "Request inserted successfully";
                    successResponse.StatusCode = response.status;

                    objResponse = successResponse;

                }
                else if (!response.isSuccess)
                {
                    badRequestResponse.SchemeId = inbound_Scheme_BillGroups.schemeId;
                    badRequestResponse.error.Code = "bad_request";
                    badRequestResponse.error.Message = "incorrect_format";
                    badRequestResponse.error.Status = Convert.ToInt32(HttpStatusCode.BadRequest);

                    objResponse = badRequestResponse;
                }
            }

        }
        catch (Exception ex)
        {
            throw ex;           
        }
        return objResponse;

    }

    #endregion

    [HttpPost]
    [UnitOfWork]
    [Route("api/Scheme/InsertSchemeAsync_ADO")]
    public async Task<Tuple<string, int, string, string>> InsertSchemeAsync_ADO(List<Inbound_Scheme_BillGroups> inbound_Scheme_BillGroups)
    {
        bool result = false;
        string msg = string.Empty;

        var tuple = await _ISchemeAppService.InsertSchemeAsync_ADO(inbound_Scheme_BillGroups);

        return new Tuple<string, int, string, string>(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);

    }

    [NonAction]
    public void LogWrite(StringBuilder sb, string fileName)
    {
        string logPath = @"C:\OldMutual\Mimo_Scheme\Mimo_Scheme\src\OldMutual.Scheme.HttpApi";

        try
        {
            //string filePath = _hEnvironment.WebRootPath + logPath + "//" + "Log_" + DateTime.Now.ToString("ddmmyyyy") + ".txt";
            string filePath = _hEnvironment.WebRootPath + logPath + "//" + fileName + ".txt";
            System.IO.File.AppendAllText(filePath, sb.ToString());
        }
        catch (Exception ex)
        {
        }
    }

    [HttpGet]
    [Route("all")]
    public Task<ListResultDto<Inbound_Mimo_CustomerDto>> GetListAsync()
    {
        return _ISchemeAppService.GetListAsync();
    }
}
