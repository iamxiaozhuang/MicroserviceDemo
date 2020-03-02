using AutoMapper;
using ServiceCommon;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using ProductService.Infrastructure.Models;
using ProductService.Infrastructure.DBContext;

namespace ProductService.Application.BasketSvc
{
    
    public class CreateOrderRequest : IRequest<int>
    {
        public CreateOrderModel Model { get; set; }
    }

    public class CreateOrderHandler : IRequestHandler<CreateOrderRequest, int>
    {
        private readonly ProductDBContext dbContext;
        private readonly IMapper autoMapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ICapPublisher capBus;
        public CreateOrderHandler(ProductDBContext _dbContext, IMapper _autoMapper, IHttpContextAccessor _httpContextAccessor, ICapPublisher _capBus)
        {
            dbContext = _dbContext;
            autoMapper = _autoMapper;
            httpContextAccessor = _httpContextAccessor;
            capBus = _capBus;

        }

        public async Task<int> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            var strategy = dbContext.Database.CreateExecutionStrategy();
            await strategy.ExecuteAsync(async () =>
            {
                using (var trans = dbContext.Database.BeginTransaction(capBus, autoCommit: true))
                {
                     //业务代码
                     var query = dbContext.Products.FirstOrDefault(p => p.ProductCode == request.Model.ProductCode);
                    if (query == null)
                    {
                        throw new FriendlyException(404, $"The product: {request.Model.ProductCode} does not exists.");

                    }
                    query.ProductAmount--;

                    string orderNO = DateTime.Now.ToString("yyyyMMddHHmmssfff").ToString();

                    string accessToken = await httpContextAccessor.HttpContext.GetTokenAsync("access_token");
                    CreateOrderCapMessage capMessage = new CreateOrderCapMessage() { AccessToken = accessToken,OrderNO = orderNO, ProductCode = query.ProductCode };
                    capBus.Publish("productservice.orderingservice.createorder", capMessage);

                    await dbContext.SaveChangesAsync(cancellationToken);
                }
            });
            return 1;
        }
    }

}
