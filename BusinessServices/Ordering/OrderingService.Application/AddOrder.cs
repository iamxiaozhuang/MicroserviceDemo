using MediatR;
using OrderingService.Domain.Entities;
using OrderingService.Domain.Models;
using ProductService.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderingService.Application
{
    public class AddOrderRequest : IRequest<int>
    {
        public AddOrderModel Model { get; set; }
    }

    public class AddOrderHandler : IRequestHandler<AddOrderRequest, int>
    {
        private readonly OrderingDBContext dbContext;
        public AddOrderHandler(OrderingDBContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<int> Handle(AddOrderRequest request, CancellationToken cancellationToken)
        {
            Order order = new Order() { ID = Guid.NewGuid(), OrderCode = request.Model.OrderNO, OrderName = request.Model.ProductCode + "Order" };
            dbContext.Orders.Add(order);
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
