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
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using ProductService.Infrastructure.Models;
using ProductService.Infrastructure.DBContext;
using ProductService.Domain.Entities;

namespace ProductService.Application.ProductSvc
{
    
    public class GetProductRequest : IRequest<GetProductModel>
    {
        public BaseModel Model { get; set; }
    }

    public class GetProductHandler : IRequestHandler<GetProductRequest, GetProductModel>
    {
        private readonly ProductDBReadOnlyContext dbContext;
        private readonly IMapper autoMapper;
        public GetProductHandler(ProductDBReadOnlyContext _dbContext, IMapper _autoMapper)
        {
            dbContext = _dbContext;
            autoMapper = _autoMapper;
        }

        public async Task<GetProductModel> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            var query = dbContext.Products.Where(p => p.ID == request.Model.ID);
            if (query.Count() < 1)
            {
                throw new FriendlyException()
                {
                    ExceptionCode = 404,
                    ExceptionMessage = $"The product ID: {request.Model.ID} does not exist."
                };
            }
            //return autoMapper.Map<GetProductModel>(await query.FirstAsync());
            return await query.ProjectTo<GetProductModel>(autoMapper.ConfigurationProvider).FirstAsync(cancellationToken);
        }
    }
}
