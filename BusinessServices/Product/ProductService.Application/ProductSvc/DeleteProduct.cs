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
using ProductService.Infrastructure.DBContext;

namespace ProductService.Application.ProductSvc
{
    
    public class DeleteProductRequest : IRequest<int>
    {
        public BaseModel Model { get; set; }
    }

    public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, int>
    {
        private readonly ProductDBContext dbContext;
        private readonly IMapper autoMapper;
        public DeleteProductHandler(ProductDBContext _dbContext, IMapper _autoMapper)
        {
            dbContext = _dbContext;
            autoMapper = _autoMapper;
        }

        public async Task<int> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
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
            dbContext.Products.Remove(query.First());
            return await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
