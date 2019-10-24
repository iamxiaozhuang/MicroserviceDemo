using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PermissionService.Application.Permission;

namespace PermissionService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/api/permission/menus")]
        [HttpGet]
        [ApiAuthorization("Permission.GetUserMenus")]
        public async Task<ActionResult<List<UserMenu>>> GetUserMenus()
        {
            return Ok(await _mediator.Send(new GetUserMenusRequest()));
        }
    }
}