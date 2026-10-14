using MediatR;
using POS.VerticalSlice.Shared;

namespace POS.VerticalSlice.Features.Product.DeleteProduct
{
    public record DeleteProductCommand(int ProductId) : IRequest<ServicesResponse>
    {
    }
}
