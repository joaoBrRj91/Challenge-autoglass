using System;
namespace ClallangeAutoGlass.Business.Entities
{
	public class Product : BaseEntity
    {

        protected Product()
        {

        }

        public Product(
            string description,
            bool status,
            DateTime fabricationDate,
            DateTime validationDate)
        {
            Description = description;
            Status = status;
            FabricationDate = fabricationDate;
            ExpirationDate = validationDate;
        }

        public string Description { get; set; }

        public bool Status { get; set; }

        public DateTime FabricationDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int SupplierId { get; set; }

        public Supplier Supplier { get; set; }

    }
}

