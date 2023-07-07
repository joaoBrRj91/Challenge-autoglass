using System;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;
using ClallangeAutoGlass.Business.Interfaces.Notifications;
using ClallangeAutoGlass.Business.Interfaces.Repositories;
using ClallangeAutoGlass.Business.Interfaces.Services;
using ClallangeAutoGlass.Business.Validations;

namespace ClallangeAutoGlass.Business.Implementations.Services
{
	public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IProductRepository productRepository;
        private readonly INotificator notificator;

        public SupplierService(ISupplierRepository supplierRepository,
            IProductRepository productRepository,
            INotificator notificator) : base(notificator)
		{
            this.supplierRepository = supplierRepository;
            this.productRepository = productRepository;
            this.notificator = notificator;
        }

        public async Task<IEnumerable<Supplier>> GetAll(Pagination? pagination = null)
        {
            var suppliers = await supplierRepository.GetAll(pagination);

            return suppliers;
        }

        public async Task<bool> Add(Supplier supplier)
        {
            if (!RunValidation(new SupplierValidation(), supplier)) return false;

            var documentExists = await supplierRepository.IsHaveSupplierWithDocument(supplier.Document);

            if(documentExists)
            {
                Notify("This document already exists.");
                return false;
            }

            supplier.Status = true;
            await supplierRepository.Add(supplier);

            return true;
        }

        public async Task<bool> Update(Supplier supplier)
        {
            if (!RunValidation(new SupplierValidation(), supplier)) return false;

            var supplierByDocument = await supplierRepository.GetByDocument(supplier.Document)!;

            if(supplierByDocument is null)
            {
                Notify("This supplier with this document dont exist.");
                return false;
            }

            supplierByDocument.Description = supplier.Description;

            await supplierRepository.Update(supplierByDocument);
            return true;
            
        }

        public async Task<bool> Remove(string document)
        {
            var supplierByDocument = await supplierRepository.GetByDocument(document)!;

            if (supplierByDocument is null)
            {
                Notify("This supplier with this document dont exist.");
                return false;
            }

            var supplierHaveProducts =  await productRepository.IsHaveProductsSupplier(supplierId: supplierByDocument.Id);

            if(supplierHaveProducts)
            {
                Notify("The supplier have products registered");
                return false;
            }


            supplierByDocument.Status = false;

            await supplierRepository.Update(supplierByDocument);
            return true;

        }

        public void Dispose()
        {
            supplierRepository?.Dispose();
            productRepository?.Dispose();
        }

    }
}

