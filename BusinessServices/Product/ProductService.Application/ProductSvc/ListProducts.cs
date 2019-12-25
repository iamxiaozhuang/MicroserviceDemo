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

namespace ProductService.Application.ProductSvc
{
    
    public class ListProductsRequest : IRequest<ListModel<ListProductModel>>
    {
        public QueryModel<QueryProductModel> Model { get; set; }
    }

    public class ListProductsHandler : IRequestHandler<ListProductsRequest, ListModel<ListProductModel>>
    {
        private readonly ProductDBReadOnlyContext dbContext;
        private readonly IMapper autoMapper;
        public ListProductsHandler(ProductDBReadOnlyContext _dbContext, IMapper _autoMapper)
        {
            dbContext = _dbContext;
            autoMapper = _autoMapper;
        }

        public async Task<ListModel<ListProductModel>> Handle(ListProductsRequest request, CancellationToken cancellationToken)
        {
            ListModel<ListProductModel> listModel = new ListModel<ListProductModel>();
            QueryModel<QueryProductModel> queryModel = request.Model;
            var query = dbContext.Products.AsQueryable();
            if (queryModel.QueryEntity != null && !string.IsNullOrEmpty(queryModel.QueryEntity.ProductCode))
            {
                query = query.Where(p => p.ProductCode.Contains(queryModel.QueryEntity.ProductCode));
            }
            if (queryModel.QueryEntity != null && !string.IsNullOrEmpty(queryModel.QueryEntity.ProductName))
            {
                query = query.Where(p => p.ProductName.Contains(queryModel.QueryEntity.ProductName));
            }
            if (queryModel.QueryEntity != null && Guid.Empty != queryModel.QueryEntity.CategoryId)
            {
                query = query.Where(p => p.CategoryId == queryModel.QueryEntity.CategoryId);
            }
            listModel.TotalRecotrdCount = query.Count();
            query = query.OrderBy(p => p.ProductName).Skip(queryModel.PageSize * queryModel.PageIndex).Take(queryModel.PageSize);
            listModel.ListEntity = await query.ProjectTo<ListProductModel>(autoMapper.ConfigurationProvider).ToListAsync(cancellationToken);
            return listModel;
        }
    }
}
