using System;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;
using ClallangeAutoGlass.Business.Interfaces.Notifications;
using ClallangeAutoGlass.Business.Interfaces.Repositories;
using ClallangeAutoGlass.Business.Interfaces.Services;

namespace ClallangeAutoGlass.Business.Implementations.Services
{
	public class SupplierService : BaseService, ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly INotificator notificator;

        public SupplierService(ISupplierRepository supplierRepository,
            INotificator notificator) : base(notificator)
		{
            this.supplierRepository = supplierRepository;
            this.notificator = notificator;
        }

        public async Task<IEnumerable<Supplier>> GetAll(Pagination? pagination = null)
        {
            var suppliers = await supplierRepository.GetAll(pagination);

            return suppliers;
        }

        public Task Add(Supplier product)
        {
            throw new NotImplementedException();
        }

        public Task Update(Supplier product)
        {
            throw new NotImplementedException();
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}

