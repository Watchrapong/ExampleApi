using System.Net.Mime;

using Asp.Versioning;

using AssetManagement.Api.ActionFilters;
using AssetManagement.Api.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagement.Api.Controllers;

[Authorize]
[ApiVersion(1.0)]
[Route("[controller]")]
[ApiController]
[ProducesResponseType<FailResponse>(StatusCodes.Status400BadRequest)]
[ProducesResponseType<FailResponse>(StatusCodes.Status500InternalServerError)]
[Produces(MediaTypeNames.Application.Json)]
[TypeFilter<ModelStateValidateFilterAction>]
public abstract class BaseApiController : ControllerBase
{
    protected IBaseResponse Success()
    {
        return new SuccessResponse();
    }

    protected IBaseResponse Success<T>(T data) where T : IApiResponse
    {
        return new SuccessResponse<T>()
        {
            Data = data
        };
    }

    protected IBaseResponse Success<T>(List<T> data) where T : IApiResponse
    {
        return new SuccessListResponse<T>()
        {
            Data = data
        };
    }
}