using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary;
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
        [Route("/api/resource/menus")]
        [HttpPost]
        public async Task<ActionResult<List<UserMenu>>> GetUserMenus([FromBody] List<string> allowResourceCodes)
        {
            return Ok(await _mediator.Send(new GetUserMenusRequest() { AllowResourceCodes = allowResourceCodes }));
        }
    }
}