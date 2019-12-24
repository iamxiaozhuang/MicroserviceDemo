using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceCommon;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.ProductSvc;
using ProductService.Domain.Models;

namespace ProductService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        // GET: api/Product
        [HttpGet]
        [ApiAuthorization("product.list")]
        public IEnumerable<string> GetProducts()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        [ApiAuthorization("product.get")]
        public string Get(Guid id)
        {
            return "value";
        }

        // POST: api/Product
        /// <summary>
        /// 新增单个产品
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [Produces("application/json")]
        [ApiAuthorization("product.add")]
        public async Task<ActionResult<int>> AddProduct([FromBody] AddProductModel value)
        {
            return Ok(await _mediator.Send(new AddProductRequest() { AddProductModel = value }));
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        [ApiAuthorization("product.update")]
        public void Update(Guid id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ApiAuthorization("product.delete")]
        public void Delete(Guid id)
        {
        }
    }
}
