using HR_Managment.Application.DTOs.LeaveType;
using HR_Managment.Application.Features.LeaveTypes.Requests.Commands;
using HR_Managment.Application.Features.LeaveTypes.Requests.Queries;
using HR_Managment.Persistence;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HR_Managment.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LeaveTypesController : ControllerBase
{
    private readonly IMediator _mediator;
    public LeaveTypesController(LeaveManagmentDbContext context, IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET: api/LeaveTypes
    [HttpGet]
    public async Task<ActionResult<List<LeaveTypeDto>>> GetLeaveTypes()
    {
        var leaveTypes = await _mediator.Send(new GetLeaveTypeListRequest());
        return Ok(leaveTypes);
    }
    // GET: api/LeaveTypes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaveTypeDto>> GetLeaveType(int id)
    {
        var leaveType = await _mediator.Send(new GetLeaveTypeDetailRequest() { Id = id });
        if (leaveType == null)
        {
            return NotFound();
        }
        return Ok(leaveType);
    }
    // PUT: api/LeaveTypes/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutLeaveType(int id, CreateLeaveTypeDto leaveType)
    {
        var result = await _mediator.Send(new UpdateLeaveTypeCommand() { LeaveTypeDto = leaveType });
        if (!result.Succeeded)
        {
            return result.StatusCode == 404
                ? NotFound(result.Message)
                : BadRequest(result.Message);
        }
        return NoContent();
    }
    // POST: api/LeaveTypes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<LeaveTypeDto>> PostLeaveType(CreateLeaveTypeDto leaveType)
    {
        var response = await _mediator.Send(new CreateLeaveTypeCommand() { LeaveTypeDto = leaveType });
        return CreatedAtAction("GetLeaveType", new { id = response }, leaveType);
    }
    // DELETE: api/LeaveTypes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLeaveType(int id)
    {
        var result = await _mediator.Send(new DeleteLeaveTypeCommand() { Id = id });
        if (!result.Succeeded)
        {
            return result.StatusCode == 404
                ? NotFound(result.Message)
                : BadRequest(result.Message);
        }
        return NoContent();
    }
}