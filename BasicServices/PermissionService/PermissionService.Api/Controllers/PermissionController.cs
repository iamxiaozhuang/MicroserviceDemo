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
    public class UserPermissionController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public UserPermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("/api/getpermission/roleassignments/")]
        [HttpGet]
        [ApiAuthorization("GetPermission.RoleAssignments")]
        public async Task<ActionResult<List<RoleAssignmentModel>>> GetRoleAssignments(string userSubject)
        {
            return Ok(await _mediator.Send(new GetRoleAssignmentsRequest()));
        }

        [Route("/api/getpermission/{roleAssignmentID}")]
        [HttpGet]
        [ApiAuthorization("GetPermission.CurrentUserPermission")]
        public async Task<ActionResult<CurrentUserPermission>> GetUserPermission(Guid roleAssignmentID)
        {
            return Ok(await _mediator.Send(new GetUserPermissionRequest() { RoleAssignmentID = roleAssignmentID}));
        }
    }
}