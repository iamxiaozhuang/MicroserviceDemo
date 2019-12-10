using DotNetCore.CAP;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ProductService.Domain.Models;
using Refit;
using ServiceCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Application
{

    public interface ISubscriberService
    {
        Task CreateOrder(CreateOrderCapMessage capMessage);
    }


    public class SubscriberService : ISubscriberService, ICapSubscribe
    {
        public IConfiguration Configuration { get; }
    
        public SubscriberService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

          

        [CapSubscribe("productservice.orderingservice.createorder")]
        public async Task CreateOrder(CreateOrderCapMessage capMessage)
        {
            ISubscriberCallApi callApi = RestService.For<ISubscriberCallApi>(Configuration["ApiGatewayService:Url"],
             new RefitSettings() { AuthorizationHeaderValueGetter = () => Task.FromResult<string>(capMessage.AccessToken) });
             await callApi.AddOrder(new AddOrderModel() { ProductCode = capMessage.ProductCode });
        }
    }

    public interface ISubscriberCallApi
    {
        [Post("/OrderingService/ordering/")]
        [Headers("Authorization: Bearer")]
        Task<int> AddOrder([Body]AddOrderModel model);

    }


    public class AddOrderModel : BaseModel
    {
        public string ProductCode { get; set; }
    }
}
