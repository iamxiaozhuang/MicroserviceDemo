using CommonLibrary;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PermissionService.Application.Permission
{

    public class GetUserMenusRequest : IRequest<List<UserMenu>>
    {
    }

    public class GetUserMenusHandler : IRequestHandler<GetUserMenusRequest, List<UserMenu>>
    {
        private readonly ICallSystemServiceApi callSystemServiceApi;
        private readonly IUserPermissionCache userPermissionCache;
        public GetUserMenusHandler(IUserPermissionCache _userPermissionCache, ICallSystemServiceApi _callSystemServiceApi)
        {
            callSystemServiceApi = _callSystemServiceApi;
            userPermissionCache = _userPermissionCache;
        }

        public async Task<List<UserMenu>> Handle(GetUserMenusRequest request, CancellationToken cancellationToken)
        {
            UserPermission userPermission = await userPermissionCache.GetCurrentUserPermission();
            List<UserMenu> userMenus = await callSystemServiceApi.GetUserMenus(userPermission.AllowResourceCodes);

            return userMenus;

        }
    }
}
