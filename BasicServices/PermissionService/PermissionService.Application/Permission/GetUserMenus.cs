using ServiceCommon;
using ServiceCommon.Caches;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceCommon.Models;

namespace PermissionService.Application.Permission
{

    public class GetUserMenusRequest : IRequest<List<UserMenu>>
    {
    }

    public class GetUserMenusHandler : IRequestHandler<GetUserMenusRequest, List<UserMenu>>
    {
        private readonly IUserPermissionCache userPermissionCache;
        private readonly ISystemDataCache systemDataCache;
        public GetUserMenusHandler(IUserPermissionCache _userPermissionCache, ISystemDataCache _systemDataCache)
        {
            systemDataCache = _systemDataCache;
            userPermissionCache = _userPermissionCache;
        }

        public async Task<List<UserMenu>> Handle(GetUserMenusRequest request, CancellationToken cancellationToken)
        {
            UserPermission userPermission = await userPermissionCache.GetCurrentUserPermission();
            List<ResourceData> resources = await systemDataCache.GetResourceData();
            resources = resources.Where(p => p.ResourceType == EnumResourceType.Menu && userPermission.AllowMenuCodes.Contains(p.ResourceCode)).ToList();

            var rootResource = resources.First(p => p.ID == Guid.Parse("88888888-8888-8888-8888-888888888888"));
            resources.Remove(rootResource);
            List<UserMenu> userMenus = new List<UserMenu>();
            UserMenu rootMenu = new UserMenu() { MenuCode = rootResource.ResourceCode, MenuName = rootResource.ResourceName, SortNO = rootResource.SortNO };
            userMenus.Add(rootMenu);
            BuildUserMenus(resources, rootResource, rootMenu);
            return userMenus;
        }

        private void BuildUserMenus(List<ResourceData> resources, ResourceData currentResource, UserMenu currentMenu)
        {
            List<ResourceData> childrenResources = resources.Where(p => p.ParentResourceID == currentResource.ID).ToList();
            if (childrenResources.Count > 0)
            {
                currentMenu.ChildrenMenus = new List<UserMenu>();
                foreach (var resource in childrenResources)
                {
                    UserMenu userMenu = new UserMenu() { MenuCode = resource.ResourceCode, MenuName = resource.ResourceName, SortNO = resource.SortNO };
                    currentMenu.ChildrenMenus.Add(userMenu);
                    BuildUserMenus(resources, resource, userMenu);
                }
            }
        }
    }
}
