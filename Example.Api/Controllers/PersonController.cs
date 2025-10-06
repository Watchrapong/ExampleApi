using Example.Api.Models;
using Example.Api.Models.Person;
using ExampleApi.Core.Dtos.Person;
using ExampleApi.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Example.Api.Controllers;

public class PersonController : BaseApiController
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    [HttpGet]
    public async Task<IBaseResponse> Get([FromQuery] GetPersonListQuery query)
    {
        var personPaging = await _personService.GetPersonListAsync(query);
        
        var page = GetPersonListResponse.FromDto(personPaging);

        return Success(page);
    }

    [HttpPost]
    [ProducesResponseType(typeof(SuccessResponse<CreatePersonResponse>), StatusCodes.Status200OK)]
    public async Task<IBaseResponse> CreatePersonAsync([FromBody] CreatePersonRequest request, CancellationToken cancellationToken)
    {
        var personId = await _personService.CreatePersonAsync(request.ToDto(), cancellationToken);
        var response = new CreatePersonResponse { Id = personId };

        return Success(response);
    }
    
    
}