using System;
using System.Net;
using AutoMapper;
using ChallengeAutoGlass.Application.AppServices.Interfaces;
using ChallengeAutoGlass.Application.Dtos;
using ChallengeAutoGlass.Application.Dtos.Creates;
using ChallengeAutoGlass.Application.Responses;
using ClallangeAutoGlass.Business.Entities;
using ClallangeAutoGlass.Business.Implementations.Paging;
using ClallangeAutoGlass.Business.Interfaces.Notifications;
using ClallangeAutoGlass.Business.Interfaces.Services;

namespace ChallengeAutoGlass.Application.AppServices
{
    public class SupplierAppService : ISupplierAppService
    {
        private readonly ISupplierService supplierService;
        private readonly INotificator notificator;
        private readonly IMapper mapper;

        public SupplierAppService(ISupplierService supplierService,
            INotificator notificator, IMapper mapper)
        {
            this.supplierService = supplierService;
            this.notificator = notificator;
            this.mapper = mapper;
        }

        public async Task<BaseResponse> GetAll(Pagination? pagination = null)
        {
            var suppliers = await supplierService.GetAll(pagination);

            var suppliersDto = mapper.Map<IEnumerable<SuppliersDto>>(suppliers);

            return new BaseResponse
            {
                IsSuccess = !notificator.IsHaveNotifications(),
                StatusCode = notificator.IsHaveNotifications() ? HttpStatusCode.BadRequest : HttpStatusCode.OK,
                Errors = notificator.GetNotifications().Select(m => m.Message).ToList(),
                Result = suppliersDto
            };
        }

        public async Task<BaseResponse> Add(AddSupplierDto supplier)
        {
            var supplierEntity = mapper.Map<Supplier>(supplier);

            var isSuccessProcess = await supplierService.Add(supplierEntity);

            return new BaseResponse
            {
                IsSuccess = isSuccessProcess,
                StatusCode = !isSuccessProcess ? HttpStatusCode.BadRequest : HttpStatusCode.OK,
                Errors = notificator.GetNotifications().Select(m => m.Message).ToList(),
                Result = supplier
            };
        }

        public async Task<BaseResponse> Update(UpdateSupplierDto supplier)
        {
            var supplierEntity = mapper.Map<Supplier>(supplier);

            var isSuccessProcess = await supplierService.Update(supplierEntity);

            return new BaseResponse
            {
                IsSuccess = isSuccessProcess,
                StatusCode = !isSuccessProcess ? HttpStatusCode.BadRequest : HttpStatusCode.OK,
                Errors = notificator.GetNotifications().Select(m => m.Message).ToList(),
                Result = supplier

            };
        }

        public async Task<BaseResponse> Remove(string document)
        {
            var isSuccessProcess = await supplierService.Remove(document);

            return new BaseResponse
            {
                IsSuccess = isSuccessProcess,
                StatusCode = !isSuccessProcess ? HttpStatusCode.BadRequest : HttpStatusCode.OK,
                Errors = notificator.GetNotifications().Select(m => m.Message).ToList()

            };
        }

    }
}

