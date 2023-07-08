using System;
namespace ChallengeAutoGlass.Application.Dtos
{
	public class ProductGetAllDto
	{
        public string Sku { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime FabricationDate { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}

