using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderingService.Application;
using OrderingService.Domain.Models;
using ServiceCommon;

namespace OrderingService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingController : ControllerBase
    {

        protected readonly IMediator _mediator;
        public OrderingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ApiAuthorization("ordering.add")]
        public async Task<ActionResult<int>> AddOrder([FromBody] AddOrderModel value)
        {
            return Ok(await _mediator.Send(new AddOrderRequest() { Model = value }));
        }
    }
}