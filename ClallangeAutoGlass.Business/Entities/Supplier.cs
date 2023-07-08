using System;
namespace ClallangeAutoGlass.Business.Entities
{
	public class Supplier : BaseEntity
	{

		public string Description { get; set; }

        public string Document { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}

