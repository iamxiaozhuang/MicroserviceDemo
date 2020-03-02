using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceCommon;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductService.Application.ProductSvc;
using ProductService.Infrastructure.Models;
using ServiceCommon.Models;

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
        /// <summary>
        /// 获取产品列表
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet]
        [ApiAuthorization("product.list")]
        public async Task<ActionResult<ListModel<ListProductModel>>> GetProducts([FromQuery] QueryModel<QueryProductModel> value)
        {
            return Ok(await _mediator.Send(new ListProductsRequest() { Model = value }));
        }

        // GET: api/Product/5
        /// <summary>
        /// 获取单个产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "Get")]
        [ApiAuthorization("product.get")]
        public async Task<ActionResult<GetProductModel>> GetProduct(Guid id)
        {
            return Ok(await _mediator.Send(new GetProductRequest() { Model = new BaseModel() { ID = id } }));
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
            return Ok(await _mediator.Send(new AddProductRequest() { Model = value }));
        }

        // PUT: api/Product/5
        /// <summary>
        /// 更新单个产品
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        [ApiAuthorization("product.update")]
        public async Task<ActionResult<int>> UpdateProduct([FromBody] UpdateProductModel value)
        {
            return Ok(await _mediator.Send(new UpdateProductRequest() { Model = value }));
        }

        // DELETE: api/ApiWithActions/5
        /// <summary>
        /// 删除单个产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [ApiAuthorization("product.delete")]
        public async Task<ActionResult<int>> DeleteProduct(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteProductRequest() { Model = new BaseModel() { ID = id } }));
        }
    }
}
