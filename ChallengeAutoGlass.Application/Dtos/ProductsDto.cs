using System;
namespace ChallengeAutoGlass.Application.Dtos
{
	public class ProductsDto
	{
        public ProductsDto()
        {
            Supplier = new SuppliersDto();
        }

        public string Sku { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime FabricationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public SuppliersDto Supplier { get; set; }

    }
}

