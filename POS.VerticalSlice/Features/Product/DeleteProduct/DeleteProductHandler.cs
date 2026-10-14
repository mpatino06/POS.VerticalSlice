using MediatR;
using POS.VerticalSlice.Infrastructure;
using POS.VerticalSlice.Shared;

namespace POS.VerticalSlice.Features.Product.DeleteProduct
{
    public class DeleteProductHandler(POSContext context)
        : IRequestHandler<DeleteProductCommand, ServicesResponse>
    {
        public async Task<ServicesResponse> Handle(DeleteProductCommand request, 
            CancellationToken cancellationToken)
        {
            var product = await context.Products.FindAsync(new object[] { request.ProductId }, cancellationToken);
            if (product is null)
                return new ServicesResponse(false, "Product not found.");

            product.AuditDeleteUser = 1;
            product.AuditDeleteDate = DateTime.UtcNow;

            context.Products.Update(product);
            //context.Entry(product).Property(x => x.AuditCreateUser).IsModified = false; // Prevent modification of AuditCreateUser
            //context.Entry(product).Property(x => x.AuditCreateDate).IsModified = false; // Prevent modification of AuditCreateDate
            //context.Entry(product).Property(x => x.AuditUpdateUser).IsModified = false; // Prevent modification of AuditCreateUser
            //context.Entry(product).Property(x => x.AuditDeleteUser).IsModified = false; // Prevent modification of AuditCreateDate
            await context.SaveChangesAsync(cancellationToken);

            //context.Products.Remove(product);
            //await context.SaveChangesAsync(cancellationToken);

            return new ServicesResponse(true, "Product deleted successfully."); 
        }
    }
}
