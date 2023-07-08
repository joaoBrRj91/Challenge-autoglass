using System;
namespace ChallengeAutoGlass.Application.Dtos
{
	public class ResultProductDto
	{

        public string? Sku { get; set; }

        public string? Description { get; set; }

        public bool Status { get; set; }

        public DateTime FabricationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public SupplierGetDto? Supplier { get; set; } 

    }
}

