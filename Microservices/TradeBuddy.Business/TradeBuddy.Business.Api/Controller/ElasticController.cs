using TradeBuddy.Business.Application.Commands;
using TradeBuddy.Business.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Business.Application.Commands.Elastic;
using TradeBuddy.Business.Application.Service.Elastic;

namespace TradeBuddy.Business.Api.Controller;

[ApiController]
[Route("api/[controller]")]
public class ElasticController : ControllerBase
{
    private readonly IMediator _mediator;

    public ElasticController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("sync")]
    public async Task<IActionResult> SyncBusinessesToElastic()
    {
        await _mediator.Send(new SyncBusinessesToElasticCommand());
        return Ok("Data synced to Elasticsearch.");
    }

    [HttpGet("search")]
    public async Task<IActionResult> SearchBusinesses([FromQuery] SearchBusinessesQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}
