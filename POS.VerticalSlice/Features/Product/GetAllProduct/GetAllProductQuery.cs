using MediatR;

namespace POS.VerticalSlice.Features.Product.GetAllProduct
{
    public record GetAllProductQuery : IRequest<IEnumerable<GetProductResponse>>
    {
    }
}
