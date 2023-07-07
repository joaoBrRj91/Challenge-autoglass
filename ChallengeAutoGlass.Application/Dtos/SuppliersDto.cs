using System;
namespace ChallengeAutoGlass.Application.Dtos
{
	public class SuppliersDto
	{
        public SuppliersDto() => Products = new List<ProductsDto>();

        public string? Description { get; set; }

        public string? Document { get; set; }

        public List<ProductsDto> Products { get; set; }
    }
}

