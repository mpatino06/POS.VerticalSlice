using Mapster;
using MediatR;
using POS.VerticalSlice.Infrastructure;
using POS.VerticalSlice.Shared;

//Usamos Mapster para mapear el objeto de solicitud CreateProductRequest al objeto de dominio Product. Esto nos permite convertir fácilmente los datos de la solicitud en una entidad
//de dominio que se puede persistir en la base de datos.
namespace POS.VerticalSlice.Features.Product.CreateProduct;

public class CreateProductHandle(POSContext context)
    : IRequestHandler<CreateProductCommand, ServicesResponse>
{
    public async Task<ServicesResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = request.Product.Adapt<Domain.Product>();

        product.AuditCreateUser = 1;
        product.AuditCreateDate = DateTime.Now;

        context.Products.Add(product);
        await context.SaveChangesAsync(cancellationToken);
        return new ServicesResponse(true, "Product created successfully.");
    }
}
