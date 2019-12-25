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
            var query = dbContext.Products.Where(p => p.ID == request.Model.ID).FirstOrDefault();
            if (query == null)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 404,
                    ExceptionMessage = $"The product ID: {request.Model.ID} does not exist."
                };
            }
            //var product = autoMapper.Map<Product>(request.Model);
            query.ProductName = request.Model.ProductName;
            query.ProductAmount = request.Model.ProductAmount;
            query.ProductPrice = request.Model.ProductPrice;

            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
