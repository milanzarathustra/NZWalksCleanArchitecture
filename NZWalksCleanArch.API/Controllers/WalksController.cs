using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NZWalksCleanArch.API.Commands.Walks;
using NZWalksCleanArch.API.Middlewares.CustomActionFilters;
using NZWalksCleanArch.API.Queries.Walks;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.Dtos.Walks.Requests;
using NZWalksCleanArch.Entities.Models;

namespace NZWalksCleanArch.API.Controllers;

public sealed class WalksController : BaseController
{
    public WalksController(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IMediator mediator) : base(unitOfWork, mapper, mediator)
    {
    }

    [HttpGet]
    //[Authorize(Roles = "Reader, Writer")] //Either one of these roles
    public async Task<IActionResult> GetAll(
        [FromQuery] Filter filter)
    {
        var result = await mediator.Send(new GetAllWalksQuery(filter));

        return Ok(result);
    }

    [HttpGet]
    [Route("{id:Guid}")]
    //[Authorize(Roles = "Reader")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var result = await mediator.Send(new GetWalkQuery(id));

        return Ok(result);
    }

    [HttpPost]
    [ValidateModel]
    //[Authorize(Roles = "Writer")]
    public async Task<IActionResult> Create([FromBody] CreateWalkRequest createWalkRequest)
    {
        var result = await mediator.Send(new CreateWalkInfoRequest(createWalkRequest));

        return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
    }

    [HttpPut]
    [Route("{id:Guid}")]
    [ValidateModel]
    //[Authorize(Roles = "Writer")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequest updateWalkRequest)
    {
        var result = await mediator.Send(new UpdateWalkInfoRequest(id, updateWalkRequest));

        return result ? NoContent() : BadRequest();
    }

    [HttpDelete]
    [Route("{id:Guid}")]
    //[Authorize(Roles = "Writer")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var result = await mediator.Send(new DeleteWalkInfoRequest(id));

        return result ? NoContent() : BadRequest();
    }
}
