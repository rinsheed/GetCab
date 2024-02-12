using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rider.Application.Application.Rider;

namespace Rider.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RiderController : ControllerBase
{
    private readonly IMediator _mediator;

    public RiderController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRiderDetailsById(int id)
    {
        var result = await _mediator.Send(new GetRiderDetailsByIdQuery());
        return Ok(result);
    }
}

