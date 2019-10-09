using CommonLibrary.Enities;
using CommonLibrary.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Infrastructure
{
    public class ProductDBReadOnlyContext : ProductDBContext
    {
        public ProductDBReadOnlyContext(DbContextOptions<ProductDBContext> options, ICurrentUserInfoProvider currentUserInfoProvider)
                : base(options, currentUserInfoProvider)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public override int SaveChanges()
        {
            throw new FriendlyException()
            {
                ExceptionCode = 403,
                ExceptionMessage = $"ReadOnlyDBContext SaveChanges is forbidden."
            };
            //return 0;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new FriendlyException()
            {
                ExceptionCode = 403,
                ExceptionMessage = $"ReadOnlyDBContext SaveChangesAsync is forbidden."
            };
            //return new Task<int>(t => 0, cancellationToken);
        }
    }
}
