using MediatR;
using POS.VerticalSlice.Shared;

namespace POS.VerticalSlice.Features.Product.GetProductById
{
    public record GetProductByIdQuery(int ProductId)
        : IRequest<GetProductResponse>
    {
    }
}
