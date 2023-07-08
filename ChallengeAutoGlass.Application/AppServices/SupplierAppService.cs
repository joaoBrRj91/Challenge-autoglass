using System;
using System.Net;
using AutoMapper;
using ChallengeAutoGlass.Application.AppServices.Interfaces;
using ChallengeAutoGlass.Application.Dtos;
using ChallengeAutoGlass.Application.Responses;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;
using ClallangeAutoGlass.Business.Interfaces.Notifications;
using ClallangeAutoGlass.Business.Interfaces.Services;

namespace ChallengeAutoGlass.Application.AppServices
{
    public class SupplierAppService : BaseAppService,  ISupplierAppService
    {
        private readonly ISupplierService supplierService;
        private readonly INotificator notificator;
        private readonly IMapper mapper;

        public SupplierAppService(ISupplierService supplierService,
            INotificator notificator, IMapper mapper) : base(notificator)
        {
            this.supplierService = supplierService;
            this.notificator = notificator;
            this.mapper = mapper;
        }

        public async Task<BaseResponse> GetAll(Pagination? pagination = null)
        {
            var suppliers = await supplierService.GetAll(pagination);

            var suppliersDto = mapper.Map<IEnumerable<ResultSupplierDto>>(suppliers);

            return CreateResponseResultByStatusCode(HttpStatusCode.OK, suppliersDto);

        }

        public async Task<BaseResponse> Add(AddSupplierDto supplier)
        {
            var supplierEntity = mapper.Map<Supplier>(supplier);

            await supplierService.Add(supplierEntity);

            return CreateResponseResultByStatusCode(HttpStatusCode.Created, supplier);

        }

        public async Task<BaseResponse> Update(string document, UpdateSupplierDto supplier)
        {
            var supplierEntity = mapper.Map<Supplier>(supplier);

            await supplierService.Update(document, supplierEntity);

            return CreateResponseResultByStatusCode(HttpStatusCode.NoContent, supplier);
        }

        public async Task<BaseResponse> Remove(string document)
        {
            await supplierService.Remove(document);

            return CreateResponseResultByStatusCode(HttpStatusCode.OK, document);
        }

    }
}

