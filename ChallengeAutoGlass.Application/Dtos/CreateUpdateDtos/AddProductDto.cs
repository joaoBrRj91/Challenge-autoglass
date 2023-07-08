using System;
namespace ChallengeAutoGlass.Application.Dtos
{
	public class AddProductDto
	{
        public string? Description { get; set; }

        public string? SupplierDocument { get; set; }

        public DateTime FabricationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

    }
}

