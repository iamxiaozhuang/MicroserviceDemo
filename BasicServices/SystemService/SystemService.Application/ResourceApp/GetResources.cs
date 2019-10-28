using AutoMapper;
using AutoMapper.QueryableExtensions;
using ServiceCommon;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SystemService.Domain;

namespace SystemService.Application.ResourceApp
{
    public class GetResourcesRequest : IRequest<List<ResourceData>>
    {
    }

    public class GetResourceHandler : IRequestHandler<GetResourcesRequest, List<ResourceData>>
    {
        private readonly SystemDBReadOnlyContext dbContext;
        private readonly IMapper autoMapper;
        public GetResourceHandler(SystemDBReadOnlyContext _dbContext,IMapper _mapper)
        {
            dbContext = _dbContext;
            autoMapper = _mapper;
        }

        public async Task<List<ResourceData>> Handle(GetResourcesRequest request, CancellationToken cancellationToken)
        {
            return await dbContext.Resources.ProjectTo<ResourceData>(autoMapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }



    }
}
