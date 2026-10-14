using MediatR;
using POS.VerticalSlice.Features.Product.CreateProduct;
using POS.VerticalSlice.Features.Product.DeleteProduct;
using POS.VerticalSlice.Features.Product.GetAllProduct;
using POS.VerticalSlice.Features.Product.GetProductById;
using POS.VerticalSlice.Features.Product.UpdateProduct;

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
        productGroup.MapPut("/update", async (UpdateProductRequest product, ISender sender) =>
        {

            var response = await sender.Send(new UpdateProductCommand(product), CancellationToken.None);
            return response.Success
                ? Results.Ok(response)
                : Results.BadRequest(response);
        });
        productGroup.MapPut("/delete/{productId}\"", async (int productId, ISender sender) =>
        {

            var response = await sender.Send(new DeleteProductCommand(productId), CancellationToken.None);
            return response.Success
                ? Results.Ok(response)
                : Results.BadRequest(response);
        }); //we are using put because we are updating the state of the product to deleted, not actually deleting it from the database
        productGroup.MapGet("/getById/{productId}", async (int productId, ISender sender) =>
        {

            var response = await sender.Send(new GetProductByIdQuery(productId), CancellationToken.None);
            return response is not null
                ? Results.Ok(response)
                : Results.NotFound();
        });
        productGroup.MapGet("/getAll", async (ISender sender) =>
        {

            var response = await sender.Send(new GetAllProductQuery(), CancellationToken.None);
            return response is not null
                ? Results.Ok(response)
                : Results.NotFound();
        });
        return productGroup;
    }
}
