using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceCommon;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SystemService.Application.ResourceApp;

namespace SystemService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public ResourceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Route("/api/resource")]
        [HttpGet]
        public async Task<ActionResult<List<ResourceData>>> GetResources()
        {
            return Ok(await _mediator.Send(new GetResourcesRequest()));
        }
    }
}