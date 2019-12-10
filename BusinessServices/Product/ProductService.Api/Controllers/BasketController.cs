using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.BasketSvc;
using ProductService.Domain.Models;
using ServiceCommon;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public BasketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Produces("application/json")]
        [ApiAuthorization("basket.createorder")]
        public async Task<ActionResult<int>> CreateOrder([FromBody] CreateOrderModel value)
        {
            return Ok(await _mediator.Send(new CreateOrderRequest() { Model = value }));
        }
    }
}