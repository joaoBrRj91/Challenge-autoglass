using System;
namespace ClallangeAutoGlass.Business.Entities
{
	public class Product : BaseEntity
    {

        public string Sku { get; set; }

        public string Description { get; set; }

        public DateTime FabricationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

    }
}

