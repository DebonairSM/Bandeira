using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bandeira.Api.Controllers.Persons;

[Authorize]
[ApiController]
[Route("api/persons")]
public class PersonsController : ControllerBase
{
    private readonly ISender _sender;

    public PersonsController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    public async Task<IActionResult> SearchPersons(
        DateOnly startDate,
        DateOnly endDate,
        CancellationToken cancellationToken)
    {
        var query = new SearchPersonsQuery();

        var result = await _sender.Send(query, cancellationToken);

        return Ok(result);
    }
}
