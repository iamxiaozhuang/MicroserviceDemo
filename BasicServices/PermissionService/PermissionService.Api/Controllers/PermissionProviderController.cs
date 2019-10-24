using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CommonLibrary;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PermissionService.Application;
using PermissionService.Domain.Models;

namespace PermissionService.Api.Controllers
{
    [ApiController]
    public class PermissionProviderController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public PermissionProviderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/api/permissionprovider/roleassignments/")]
        [HttpGet]
        [ApiAuthorization("PermissionProvider.GetUserRoleAssignments")]
        public async Task<ActionResult<List<RoleAssignmentModel>>> GetUserRoleAssignments(string userSubject)
        {
            return Ok(await _mediator.Send(new GetRoleAssignmentsRequest()));
        }

        [Route("/api/permissionprovider/{roleAssignmentID}")]
        [HttpGet]
        [ApiAuthorization("PermissionProvider.GetUserPermission")]
        public async Task<ActionResult<UserPermission>> GetUserPermission(Guid roleAssignmentID)
        {
            return Ok(await _mediator.Send(new GetUserPermissionRequest() { RoleAssignmentID = roleAssignmentID}));
        }

      
    }
}