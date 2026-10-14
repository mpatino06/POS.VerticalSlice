using Mapster;

namespace POS.VerticalSlice.Features.Product;

public class GetProductMappingConfig
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Domain.Product, GetProductResponse>()
            .Map(dest => dest.CategoryName, src => src.Category.Name)
            .Map(dest => dest.ProviderName, src => "Test");
    }
}
