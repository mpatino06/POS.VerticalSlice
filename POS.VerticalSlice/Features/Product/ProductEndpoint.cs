using MediatR;
using POS.VerticalSlice.Features.Product.CreateProduct;

namespace POS.VerticalSlice.Features.Product;

public static class ProductEndpoint
{
    public static IEndpointConventionBuilder MapProductEndpoints(this IEndpointRouteBuilder app)
    {
        var productGroup = app.MapGroup("/product");
        productGroup.MapPost("/create", async (CreateProductRequest product, ISender sender) =>
        {
           
            var response = await sender.Send(new CreateProductCommand(product), CancellationToken.None);
            return response.Success 
                ? Results.Ok(response) 
                : Results.BadRequest(response);
        });
        return productGroup;
    }
}
