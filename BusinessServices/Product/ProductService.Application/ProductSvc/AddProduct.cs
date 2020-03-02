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
    
    public class AddProductRequest : IRequest<int>
    {
        public AddProductModel Model { get; set; }
    }

    public class AddProductHandler : IRequestHandler<AddProductRequest, int>
    {
        private readonly ProductDBContext dbContext;
        private readonly IMapper autoMapper;
        public AddProductHandler(ProductDBContext _dbContext, IMapper _autoMapper)
        {
            dbContext = _dbContext;
            autoMapper = _autoMapper;
        }

        public async Task<int> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            Product entity = autoMapper.Map<Product>(request.Model);
            var query = dbContext.Products.FirstOrDefault(p => p.ProductCode == entity.ProductCode);
            if (query != null)
            {
                throw new FriendlyException(409);
            }
            dbContext.Products.Add(entity);
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
