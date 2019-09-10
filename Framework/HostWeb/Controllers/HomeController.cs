using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Refit;

namespace HostWeb.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IActionResult Index()
        {
            ViewBag.CallTestApiResult = new Dictionary<string, string>();
            return View();
        }

        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }

        public async Task<IActionResult> CallTestApi()
        {
            var callTestApi = RestService.For<ICallTestApi>(Configuration["ApiGatewayService:Url"],
               new RefitSettings() { AuthorizationHeaderValueGetter = GetCommonServiceApiToken });
            var dic = await callTestApi.CallTestApi();
            ViewBag.CallTestApiResult = dic;
            return View("Index");
        }

        private async Task<string> GetCommonServiceApiToken()
        {
            return await HttpContext.GetTokenAsync("access_token");
        }
    }

    public interface ICallTestApi
    {
        [Get("/ProductService/values/testapi")]
        [Headers("Authorization: Bearer")]
        Task<Dictionary<string, string>> CallTestApi();

    }
}