namespace POS.VerticalSlice.Features.Product.CreateProduct;

public class CreateProductRequest
{
    public string? Code { get; set; }

    public string? Name { get; set; }

    public int Stock { get; set; }

    public string? Image { get; set; }

    public decimal SellPrice { get; set; }

    public int CategoryId { get; set; }

    public int ProviderId { get; set; }

    public int State { get; set; }
}
