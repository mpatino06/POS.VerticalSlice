using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using POS.VerticalSlice.Infrastructure;

namespace POS.VerticalSlice.Features.Product.GetAllProduct
{
    public class GetProductHandler(POSContext context)
        : IRequestHandler<GetAllProductQuery, IEnumerable<GetProductResponse>>
    {
        public async Task<IEnumerable<GetProductResponse>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            var products = await context.Products.Include(p => p.Category).ToListAsync(cancellationToken: cancellationToken);
            return products.Adapt<IEnumerable<GetProductResponse>>();
        }
    }
}
