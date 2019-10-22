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

        [Route("/api/permission/roles/")]
        [HttpGet]
        [ApiAuthorization("permission.getroles")]
        public async Task<ActionResult<List<RoleAssignmentModel>>> GetRoleAssignments(string userSubject)
        {
            return Ok(await _mediator.Send(new GetRoleAssignmentsRequest()));
        }

        [Route("/api/permission/{roleAssignmentID}")]
        [HttpGet]
        [ApiAuthorization("permission.get")]
        public async Task<ActionResult<CurrentUserPermission>> GetPermission(Guid roleAssignmentID)
        {
            return Ok(await _mediator.Send(new GetUserPermissionRequest() { RoleAssignmentID = roleAssignmentID}));
        }
    }
}