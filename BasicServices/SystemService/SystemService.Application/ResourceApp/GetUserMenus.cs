using AutoMapper;
using CommonLibrary;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SystemService.Domain;

namespace SystemService.Application.ResourceApp
{
    public class GetUserMenusRequest : IRequest<List<UserMenu>>
    {
        public List<string> AllowResourceCodes { get; set; }
    }

    public class GetUserMenuslHandler : IRequestHandler<GetUserMenusRequest, List<UserMenu>>
    {
        private readonly SystemDBReadOnlyContext dbContext;
        public GetUserMenuslHandler(SystemDBReadOnlyContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<UserMenu>> Handle(GetUserMenusRequest request, CancellationToken cancellationToken)
        {
            List<Resource> resources = await dbContext.Resources
                .Where(p => p.ResourceType == EnumResourceType.Menu && request.AllowResourceCodes.Contains(p.ResourceCode)).OrderBy(p => p.SortNO).ToListAsync();
            var rootResource = resources.First(p => p.ID == Guid.Parse("88888888-8888-8888-8888-888888888888"));
            resources.Remove(rootResource);
            List<UserMenu> menus = new List<UserMenu>();
            UserMenu rootMenu = new UserMenu() { MenuCode = rootResource.ResourceCode, MenuName = rootResource.ResourceName, SortNO = rootResource.SortNO };
            menus.Add(rootMenu);
            BuildUserMenus(resources, rootResource, rootMenu);

            return menus;
        }

        private void BuildUserMenus(List<Resource> resources, Resource currentResource, UserMenu currentMenu)
        {
            List<Resource> childrenResources = resources.Where(p => p.ParentResourceID == currentResource.ID).ToList();
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
