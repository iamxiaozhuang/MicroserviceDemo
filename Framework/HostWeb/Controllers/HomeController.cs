using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ServiceCommon;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Refit;
using System.Net.Http;
using IdentityModel.Client;
using HostWeb.Common;

namespace HostWeb.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration { get; }
        private IGeneralApiTokenProvider generalApiTokenProvider;
        private ICallApi callApi;
        public HomeController(IConfiguration configuration, IGeneralApiTokenProvider _generalApiTokenProvider)
        {
            Configuration = configuration;
            generalApiTokenProvider = _generalApiTokenProvider;
            callApi = RestService.For<ICallApi>(Configuration["ApiGatewayService:Url"],
              new RefitSettings() { AuthorizationHeaderValueGetter = () => generalApiTokenProvider.GetGeneralApiToken(HttpContext) });
        }
        public async Task<IActionResult> Index()
        {
            string generalApiAccessToken = await generalApiTokenProvider.GetGeneralApiToken(HttpContext);
            if (string.IsNullOrEmpty(generalApiAccessToken))
            {
                return SignOut("Cookies", "oidc");
            }
            List<RoleAssignmentModel> roleAssignments = await callApi.GetRoleAssignments();
            List<SelectListItem> ddlCurrentUserRolesitems = new List<SelectListItem>();
            foreach (var item in roleAssignments)
            {
                ddlCurrentUserRolesitems.Add(new SelectListItem { Text = item.ScopeName + " - " + item.RoleName, Value = item.ID.ToString() });
            }

            ViewData["ddlCurrentUserRoles"] = ddlCurrentUserRolesitems;


            return View();
        }

        public async Task<IActionResult> GetGeneralApiToken()
        {
            string generalApiAccessToken = await generalApiTokenProvider.GetGeneralApiToken(HttpContext);
            return Ok("Bearer "+generalApiAccessToken);
        }

        public async Task<IActionResult> ShowCurrentUserPermission(string roleassignmentid)
        {
            if (roleassignmentid == null) return Ok();
            UserPermission userPermission = await callApi.GetUserPermission(Guid.Parse(roleassignmentid));
            return Ok(userPermission);
        }


        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }
        public async Task<IActionResult> GetUserMenus()
        {
            var data = await callApi.GetUserMenus();
            return Ok(data);
        }
        public async Task<IActionResult> TestApigatewayCache()
        {
            var str = await callApi.TestApigatewayCache();
            return Ok(str);
        }

    }

    public interface ICallApi
    {
        [Get("/PermissionService/permissionprovider/roleassignments/")]
        [Headers("Authorization: Bearer")]
        Task<List<RoleAssignmentModel>> GetRoleAssignments();

        [Get("/PermissionService/permissionprovider/{roleAssignmentID}")]
        [Headers("Authorization: Bearer")]
        Task<UserPermission> GetUserPermission(Guid roleAssignmentID);

        [Get("/PermissionService/permission/menus")]
        [Headers("Authorization: Bearer")]
        Task<List<UserMenu>> GetUserMenus();


        [Get("/PermissionService/permission/testapigatewaycache")]
        [Headers("Authorization: Bearer")]
        Task<string> TestApigatewayCache();

    }

    public class RoleAssignmentModel : BaseModel
    {
        public string PrincipalCode { get; set; }
        public string PrincipalName { get; set; }
        public string RoleCode { get; set; }
        public string RoleName { get; set; }
        public string ScopeCode { get; set; }
        public string FullScopeCode { get; set; }
        public string ScopeName { get; set; }
        public int SortNO { get; set; }

    }
}