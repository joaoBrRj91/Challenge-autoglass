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
        private readonly ISupplierRepository supplierRepository;
        private readonly INotificator notificator;

        public ProductService(IProductRepository productRepository,
            ISupplierRepository supplierRepository,
            INotificator notificator) : base(notificator)
		{
            this.productRepository = productRepository;
            this.supplierRepository = supplierRepository;
            this.notificator = notificator;
        }

        public async Task<IEnumerable<Product>> GetAll(Pagination? pagination = null)
        {
            var products = await productRepository.GetAllWithSupplier(pagination);

            return products;
        }

        public async Task<bool> Add(Product product)
        {
            var supplierByDocument = await supplierRepository.GetByDocument(product.Supplier.Document)!;

            if(supplierByDocument is null)
            {
                Notify("This supplier with this document dont exist.");
                return false;
            }

            product.Sku = Utils.GeneratedCodByInputValue(product.Description);
            product.Status = true;
            product.SupplierId = supplierByDocument.Id;

            if (!RunValidation(new ProductValidation(), product)) return false;

            await productRepository.Add(product);
            return true;
        }

        public async Task<bool> Update(string sku, Product product)
        {

            var productBySku = await productRepository.GetBySku(sku);

            if (productBySku is null)
            {
                Notify("This product with this sku dont exist.");
                return false;
            }

            productBySku.Description = product.Description;

            if (!RunValidation(new ProductValidation(), productBySku)) return false;

            await productRepository.Update(productBySku);
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

