using AutoMapper;
using CommonLibrary;
using CommonLibrary.Base;
using MediatR;
using ProductService.Domain;
using ProductService.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Application.ProductManagement
{
    
    public class AddProductRequest : IRequest<int>
    {
        public AddProductModel AddProductModel { get; set; }
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
            Product entity = autoMapper.Map<Product>(request.AddProductModel);
            var query = dbContext.Products.FirstOrDefault(p => p.ProductCode == entity.ProductCode);
            if (query != null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 409,
                    ExceptionMessage = $"The product: {entity.ProductCode} already exists."
                };
            }
            dbContext.Products.Add(entity);
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
