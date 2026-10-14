using POS.VerticalSlice.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POS.VerticalSlice.Features.Product
{
    public class GetProductResponse
    {
        public int ProductId { get; set; }

        public string? Code { get; set; }

        public string? Name { get; set; }

        public int Stock { get; set; }

        public string? Image { get; set; }

        public decimal SellPrice { get; set; }

        public string? CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string? ProviderName { get; set; }

        public int ProviderId { get; set; }

        public int State { get; set; }




    }
}
