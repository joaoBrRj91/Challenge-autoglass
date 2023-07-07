using System;
namespace ClallangeAutoGlass.Business.Entities
{
	public class Supplier : BaseEntity
	{

       
        /*public Supplier(string description, string document)
        {
            Description = description;
            Document = document;
        }*/

		public string Description { get; set; }

        public string Document { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}

