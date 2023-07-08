using System;

namespace ChallengeAutoGlass.Application.Dtos
{
	public class ResultSupplierDto
	{

        public string? Description { get; set; }

        public string? Document { get; set; }

        public List<ProductGetDto>? Products { get; set; }
    }
}

