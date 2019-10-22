using AutoMapper;
using AutoMapper.QueryableExtensions;
using CommonLibrary;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Npgsql;
using PermissionService.Domain;
using PermissionService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PermissionService.Application
{

    public class GetRoleAssignmentsRequest : IRequest<List<RoleAssignmentModel>>
    {
    }

    public class GetRoleAssignmentslHandler : IRequestHandler<GetRoleAssignmentsRequest, List<RoleAssignmentModel>>
    {
        private readonly PermissionDBReadOnlyContext dbContext;
        private readonly IMapper autoMapper;
        private readonly CurrentUserInfo currentUserInfo;
        public GetRoleAssignmentslHandler(PermissionDBReadOnlyContext _dbContext, IMapper _autoMapper, IHttpContextAccessor _httpContextAccessor)
        {
            dbContext = _dbContext;
            autoMapper = _autoMapper;
            currentUserInfo = _httpContextAccessor.HttpContext.Items["CurrentUserInfo"] as CurrentUserInfo;
        }

        public async Task<List<RoleAssignmentModel>> Handle(GetRoleAssignmentsRequest request, CancellationToken cancellationToken)
        {
            var query = dbContext.RoleAssignments.Where(p => p.Principal.PrincipalCode == currentUserInfo.UserCode).OrderBy(p => p.Role.SortNO);
            List<RoleAssignmentModel> roleAssignmentModels = await query.ProjectTo<RoleAssignmentModel>(autoMapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return roleAssignmentModels;
        }
    }

    public class GetUserPermissionRequest : IRequest<CurrentUserPermission>
    {
        public Guid RoleAssignmentID { get; set; }
    }

    public class GetUserPermissionHandler : IRequestHandler<GetUserPermissionRequest, CurrentUserPermission>
    {
        private readonly PermissionDBReadOnlyContext dbContext;
        private readonly IMapper autoMapper;
        private readonly CurrentUserInfo currentUserInfo;
        private readonly IUserPermissionCache userPermissionCache;
        public GetUserPermissionHandler(PermissionDBReadOnlyContext _dbContext, IMapper _autoMapper, IHttpContextAccessor _httpContextAccessor, IUserPermissionCache _userPermissionCache)
        {
            dbContext = _dbContext;
            autoMapper = _autoMapper;
            currentUserInfo = _httpContextAccessor.HttpContext.Items["CurrentUserInfo"] as CurrentUserInfo;
            userPermissionCache = _userPermissionCache;
        }

        public async Task<CurrentUserPermission> Handle(GetUserPermissionRequest request, CancellationToken cancellationToken)
        {
            RoleAssignment roleAssignment;
            if (request.RoleAssignmentID == Guid.Empty)
            {
                roleAssignment = dbContext.RoleAssignments.Where(p => p.Principal.PrincipalCode == currentUserInfo.UserCode).OrderBy(p => p.Role.SortNO).First();
            }
            else
            {
                roleAssignment = dbContext.RoleAssignments.First(p => p.ID == request.RoleAssignmentID);
            }
            if (roleAssignment == null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = (int)HttpStatusCode.NotFound,
                    ExceptionMessage = $"The RoleAssignment id: {request.RoleAssignmentID} does not exist."
                };
            }
            CurrentUserPermission currentUserPermission = new CurrentUserPermission();
            currentUserPermission.RoleCode = roleAssignment.Role.RoleCode;
            currentUserPermission.AllowResourceCodes = dbContext.RolePermissions.Where(p => p.Role.ID == roleAssignment.RoleID).Select(p => p.Resource.FullResourceCode).ToList();
            currentUserPermission.ScopeCode = roleAssignment.Scope.ScopeCode;
            currentUserPermission.AllowScopeCodes = dbContext.Scopes.Where(p => p.FullScopeCode.StartsWith(roleAssignment.Scope.FullScopeCode)).Select(p => p.FullScopeCode).ToList();

            await userPermissionCache.SetCurrentUserPermission(currentUserPermission);

            return currentUserPermission;

        }
    }
}
