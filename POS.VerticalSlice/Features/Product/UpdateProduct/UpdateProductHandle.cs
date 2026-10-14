using Mapster;
using MediatR;
using POS.VerticalSlice.Infrastructure;
using POS.VerticalSlice.Shared;

namespace POS.VerticalSlice.Features.Product.UpdateProduct;

public class UpdateProductHandle(POSContext context)
    : IRequestHandler<UpdateProductCommand, ServicesResponse>
{
    public async Task<ServicesResponse> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        //var product = context.Products.FirstOrDefault(a=> a.ProductId == request.Product.ProductId);

        //if (product is null)
        //    throw new Exception("Error update"); 

        var productUpdate = request.Product.Adapt<Domain.Product>();
        productUpdate.AuditUpdateUser = 1;
        productUpdate.AuditUpdateDate = DateTime.UtcNow;
        productUpdate.ProviderId = 2;

        context.Products.Update(productUpdate);
        context.Entry(productUpdate).Property(x => x.AuditCreateUser).IsModified = false; // Prevent modification of AuditCreateUser
        context.Entry(productUpdate).Property(x => x.AuditCreateDate).IsModified = false; // Prevent modification of AuditCreateDate
        await context.SaveChangesAsync(cancellationToken);

        return new ServicesResponse(true, "Product Updated successfully. ");
    }
}
