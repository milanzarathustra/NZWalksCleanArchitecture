﻿using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NZWalksCleanArch.API.Commands.Walks;
using NZWalksCleanArch.API.Middlewares.CustomActionFilters;
using NZWalksCleanArch.API.Queries.Walks;
using NZWalksCleanArch.DataService.Repositories.Interfaces;
using NZWalksCleanArch.Entities.Dtos.Shared;
using NZWalksCleanArch.Entities.Dtos.Walks.Requests;

namespace NZWalksCleanArch.API.Controllers
{
    public class WalksController : BaseController
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
            var query = new GetAllWalksQuery(filter);

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var query = new GetWalkQuery(id);

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] CreateWalkRequest createWalkRequest)
        {
            var command = new CreateWalkInfoRequest(createWalkRequest);

            var result = await mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequest updateWalkRequest)
        {
            var command = new UpdateWalkInfoRequest(id, updateWalkRequest);

            var result = await mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteWalkInfoRequest(id);

            var result = await mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }
    }
}
