using System;
namespace ChallengeAutoGlass.Application.Dtos
{
	public class ProductsDto
	{
        public ProductsDto()
        {
            Suppliers = new SuppliersDto();
        }

        public string? Description { get; set; }

        public bool Status { get; set; }

        public string? FabricationDateFormat { get; set; }

        public string? ExpirationDateFormat { get; set; }

        public SuppliersDto Suppliers { get; set; }

    }
}

