using AuthService.Domain;
using CommonLibrary;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AuthService.Application
{
    /*

    public class GetRoleAssignmentsRequest : IRequest<IEnumerable<RoleAssignmentModel>>
    {
       public string UserSubject { get; set; }
    }

    public class GetRoleAssignmentslHandler : IRequestHandler<GetRoleAssignmentsRequest, IEnumerable<RoleAssignmentModel>>
    {
        private readonly string connectionString;
        public GetRoleAssignmentslHandler(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
           connectionString = configuration.GetValue<string>("ConnectionStrings:PermissionDBConnStr");
        }
        internal IDbConnection Connection
        {
            get
            {
                var conn = new NpgsqlConnection(connectionString);
                return conn;
            }
        }

        public async Task<IEnumerable<RoleAssignmentModel>> Handle(GetRoleAssignmentsRequest request, CancellationToken cancellationToken)
        {
            string tenantCode = request.UserSubject.Split('-')[0];
            string principalCode = request.UserSubject.Split('-')[1];
            using (IDbConnection dbConnection = Connection)
            {
                var query = @"select a.""ID"",b.""PrincipalCode"",b.""PrincipalName"",c.""RoleCode"",c.""RoleName"",d.""ScopeCode"",d.""FullScopeCode"",d.""ScopeName"",c.""SortNO"" 
                      from""RoleAssignment"" a 
                      inner join ""Principal"" b on a.""TenantCode"" = b.""TenantCode"" and a.""PrincipalID"" = b.""ID""
                      inner join ""Role"" c on a.""TenantCode"" = c.""TenantCode"" and a.""RoleID"" = c.""ID""
                      inner join ""Scope"" d on a.""TenantCode"" = d.""TenantCode"" and a.""ScopeID"" = d.""ID""
                      where b.""PrincipalCode"" = @PrincipalCode and a.""TenantCode"" = @TenantCode
                      order by c.""SortNO""";
                return await dbConnection.QueryAsync<RoleAssignmentModel>(query, new { PrincipalCode = principalCode, TenantCode = tenantCode });
            }
        }
    }

    public class GetUserPermissionRequest : IRequest<CurrentUserPermission>
    {

        public string UserSubject { get; set; }
        public Guid RoleAssignmentID { get; set; }
    }

    public class GetUserPermissionHandler : IRequestHandler<GetUserPermissionRequest, CurrentUserPermission>
    {
        private readonly string connectionString;
        protected readonly IMediator mediator;
        public GetUserPermissionHandler(IConfiguration configuration, IMediator _mediator)
        {
            connectionString = configuration.GetValue<string>("ConnectionStrings:PermissionDBConnStr");
            mediator = _mediator;
        }

        internal IDbConnection Connection
        {
            get
            {
                var conn = new NpgsqlConnection(connectionString);
                return conn;
            }
        }

        public async Task<CurrentUserPermission> Handle(GetUserPermissionRequest request, CancellationToken cancellationToken)
        {
            string tenantCode = request.UserSubject.Split('-')[0];
            string principalCode = request.UserSubject.Split('-')[1];
            using (IDbConnection dbConnection = Connection)
            {
                RoleAssignmentModel assignmentModel;
                IEnumerable<RoleAssignmentModel> roleAssignmentModels = await mediator.Send(new GetRoleAssignmentsRequest() { UserSubject = request.UserSubject });
                if (request.RoleAssignmentID == Guid.Empty)
                {
                    assignmentModel = roleAssignmentModels.First();
                }
                else
                {
                    assignmentModel = roleAssignmentModels.First(p => p.ID == request.RoleAssignmentID);
                }
                if (assignmentModel == null)
                {
                    throw new FriendlyException()
                    {
                        ExceptionCode = (int)HttpStatusCode.NotFound,
                        ExceptionMessage = $"The RoleAssignment id: {request.RoleAssignmentID} does not exist."
                    };
                }

                //写缓存


                var queryAllowResourceCodes = @"select e.""FullResourceCode""
                      from""RoleAssignment"" a
                      inner join ""Role"" c on a.""TenantCode"" = c.""TenantCode"" and a.""RoleID"" = c.""ID""
                      inner join ""RolePermissions"" d on c.""TenantCode"" = d.""TenantCode"" and c.""ID"" = d.""RoleID""
                      inner join ""Resource"" e on d.""TenantCode"" = e.""TenantCode"" and d.""ResourceID"" = e.""ID""
                      where a.""ID"" = @RoleAssignmentID and a.""TenantCode"" = @TenantCode";

                var queryAllowScopeCodes = @"select a.""FullResourceCode""
                      from""Scope"" a
                      where a.""FullScopeCode"" like @FullScopeCode and a.""TenantCode"" = @TenantCode";

              
                CurrentUserPermission currentUserPermission = new CurrentUserPermission();
                currentUserPermission.UserSubject = request.UserSubject;
                currentUserPermission.RoleCode = assignmentModel.RoleCode;
                currentUserPermission.AllowResourceCodes = dbConnection.Query<string>(queryAllowResourceCodes, new { RoleAssignmentID = assignmentModel.ID, TenantCode = tenantCode }).AsList();
                currentUserPermission.ScopeCode = assignmentModel.ScopeCode;
                currentUserPermission.AllowScopeCodes = dbConnection.Query<string>(queryAllowScopeCodes, new { FullScopeCode = assignmentModel.FullScopeCode+ "%", TenantCode = tenantCode }).AsList();

                return currentUserPermission;
            }
        }
    }
    */
}
