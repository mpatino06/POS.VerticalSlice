using MediatR;
using POS.VerticalSlice.Shared;
//Impleentamos MediatR para manejar la solicitud de creación de producto. El comando CreateProductCommand encapsula la solicitud de creación de producto
//y se utiliza para enviar la solicitud al manejador correspondiente. (implementar el patrón Mediator y facilitar la arquitectura CQRS)
namespace POS.VerticalSlice.Features.Product.CreateProduct;

public record CreateProductCommand(CreateProductRequest Product) : IRequest<ServicesResponse>
{
}
