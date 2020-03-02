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
using ProductService.Infrastructure.Models;
using ProductService.Infrastructure.DBContext;
using ProductService.Domain.Entities;

namespace ProductService.Application.ProductSvc
{
    
    public class UpdateProductRequest : IRequest<int>
    {
        public UpdateProductModel Model { get; set; }
    }

    public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, int>
    {
        private readonly ProductDBContext dbContext;
        private readonly IMapper autoMapper;
        public UpdateProductHandler(ProductDBContext _dbContext, IMapper _autoMapper)
        {
            dbContext = _dbContext;
            autoMapper = _autoMapper;
        }

        public async Task<int> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            Product query = dbContext.Products.FirstOrDefault(p => p.ID == request.Model.ID);
            if (query == null)
            {
                throw new FriendlyException(404);
            }
            //var product = autoMapper.Map<Product>(request.Model);
            //dbContext.Products.Attach(product);
            //dbContext.Entry(product).Property("ProductName").IsModified = true;
            //dbContext.Entry(product).Property("ProductAmount").IsModified = true;
            //dbContext.Entry(product).Property("ProductPrice").IsModified = true;
            query.ProductName = request.Model.ProductName;
            query.ProductAmount = request.Model.ProductAmount;
            query.ProductPrice = request.Model.ProductPrice;
            //dbContext.Products.Update(query);
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
