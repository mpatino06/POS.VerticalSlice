using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using POS.VerticalSlice.Infrastructure;

namespace POS.VerticalSlice.Features.Product.GetProductById
{
    public class GetProductByIdHandler(POSContext context)
        : IRequestHandler<GetProductByIdQuery, GetProductResponse>
    {
        public async Task<GetProductResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await context.Products
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.ProductId == request.ProductId);
            return product!.Adapt<GetProductResponse>();
            //var product = await context.Products
            //     .Where(p => p.ProductId == request.ProductId)
            //     .Select(p => new GetProductResponse
            //     {
            //         ProductId = p.ProductId,
            //         Code = p.Code,
            //         Name = p.Name,
            //         Stock = p.Stock,
            //         Image = p.Image,
            //         SellPrice = p.SellPrice,
            //         CategoryName = p.Category.Name,
            //         CategoryId = p.CategoryId,
            //         ProviderName = "Prueba",
            //         ProviderId = p.ProviderId,
            //         State = p.State
            //     }).FirstOrDefaultAsync(cancellationToken);

            // if (product == null)
            // {
            //     throw new Exception($"Product with ID {request.ProductId} not found.");
            // }
            // return product;

        }
    }
}
