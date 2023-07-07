using System;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;
using ClallangeAutoGlass.Business.Interfaces.Notifications;
using ClallangeAutoGlass.Business.Interfaces.Repositories;
using ClallangeAutoGlass.Business.Interfaces.Services;
using ClallangeAutoGlass.Business.Validations;
using ClallangeAutoGlass.Business.Validations.Documents;

namespace ClallangeAutoGlass.Business.Implementations.Services
{
	public class ProductService : BaseService, IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly INotificator notificator;

        public ProductService(IProductRepository productRepository,
            INotificator notificator) : base(notificator)
		{
            this.productRepository = productRepository;
            this.notificator = notificator;
        }

        public async Task<IEnumerable<Product>> GetAll(Pagination? pagination = null)
        {
            var products = await productRepository.GetAll(pagination);

            return products;
        }

        public async Task<bool> Add(Product product)
        {
            product.Sku = Utils.GeneratedCodByInputValue(product.Description);

            if (!RunValidation(new ProductValidation(), product)) return false;

            await productRepository.Add(product);
            return true;
        }

        public async Task<bool> Update(Product product)
        {
            if (!RunValidation(new ProductValidation(), product)) return false;

            var productBySku = await productRepository.GetBySku(product.Sku);

            if (productBySku is null)
            {
                Notify("This product with this sku dont exist.");
                return false;
            }

            productBySku.Description = product.Description;
            return true;
        }

        public async Task<bool> Remove(string sku)
        {
            var productBySku = await productRepository.GetBySku(sku);

            if (productBySku is null)
            {
                Notify("This product with this sku dont exist.");
                return false;
            }

            productBySku.Status = false;

            await productRepository.Update(productBySku);
            return true;

        }

        public void Dispose()
        {
            productRepository?.Dispose();
        }

    }
}

