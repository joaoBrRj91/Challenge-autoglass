using System;
namespace ChallengeAutoGlass.Application.Dtos
{
	public class ProductsDto
	{
        public ProductsDto()
        {
            Suppliers = new SuppliersDto();
        }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime FabricationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public SuppliersDto Suppliers { get; set; }

    }
}

