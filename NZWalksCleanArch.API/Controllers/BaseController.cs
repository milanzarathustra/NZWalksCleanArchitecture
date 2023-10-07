using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NZWalksCleanArch.DataService.Repositories.Interfaces;

namespace NZWalksCleanArch.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController : ControllerBase
{
    protected readonly IUnitOfWork unitOfWork;
    protected readonly IMapper mapper;
    protected readonly IMediator mediator;

    public BaseController(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IMediator mediator)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
        this.mediator = mediator;
    }
}
