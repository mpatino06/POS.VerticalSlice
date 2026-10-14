using MediatR;
using POS.VerticalSlice.Shared;

namespace POS.VerticalSlice.Features.Product.UpdateProduct;

public record UpdateProductCommand(UpdateProductRequest Product) 
    : IRequest<ServicesResponse> { }

