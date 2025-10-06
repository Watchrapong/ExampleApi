using System.Net.Mime;
using Example.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers;

[Route("[controller]")]
[ApiController]
[ProducesResponseType<FailResponse>(StatusCodes.Status400BadRequest)]
[ProducesResponseType<FailResponse>(StatusCodes.Status500InternalServerError)]
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