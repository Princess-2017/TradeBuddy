using MediatR;
using Microsoft.AspNetCore.Mvc;
using TradeBuddy.Appointment.Application.Command;
using TradeBuddy.Appointment.Application.Queries;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public AppointmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id = result }, result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
    [FromRoute] AppointmentId id,
    [FromBody] UpdateAppointmentCommand command)
    {
        if (id != command.AppointmentId)
            return BadRequest("The AppointmentId in the route does not match the AppointmentId in the body.");

        var result = await _mediator.Send(command);
        return result ? NoContent() : NotFound();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(AppointmentId id)
    {
        var result = await _mediator.Send(new GetAppointmentByIdQuery(id));
        return result != null ? Ok(result) : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(AppointmentId id)
    {
        var result = await _mediator.Send(new DeleteAppointmentCommand(id));
        return result ? NoContent() : NotFound();
    }
}
