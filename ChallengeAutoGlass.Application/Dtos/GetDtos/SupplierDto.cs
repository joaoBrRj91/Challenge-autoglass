using System;

namespace ChallengeAutoGlass.Application.Dtos
{
	public class SupplierDto
	{

        public string? Description { get; set; }

        public string? Document { get; set; }

        public List<ProductGetAllDto>? Products { get; set; }
    }
}

