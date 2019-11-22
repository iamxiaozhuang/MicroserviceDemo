using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SystemService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class HeathCheckController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public ActionResult<IEnumerable<string>> Test()
        {
            return new string[] { "API From SystemService" };
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [Route("liveness")]
        public async Task<IActionResult> Liveness()
        {
            return await Task.Run<IActionResult>(() =>
            {
                Console.WriteLine("{0} API is alive.", DateTime.Now);
                return this.Ok();
            });
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.ServiceUnavailable)]
        [Route("readiness")]
        public async Task<IActionResult> Readiness()
        {
            return await Task.Run<IActionResult>(() =>
            {
                Console.WriteLine("{0} API is ready.", DateTime.Now);
                return this.Ok();
            });
        }
    }
}
