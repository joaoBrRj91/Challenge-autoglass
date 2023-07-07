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
    public class ProductsAppService : IProductAppService
    {
        private readonly IProductService productService;
        private readonly INotificator notificator;
        private readonly IMapper mapper;

        public ProductsAppService(IProductService productService,
            INotificator notificator, IMapper mapper)
        {
            this.productService = productService;
            this.notificator = notificator;
            this.mapper = mapper;
        }

        public async Task<BaseResponse> GetAll(Pagination? pagination = null)
        {
            var products = await productService.GetAll(pagination);

            var productsDto = mapper.Map<IEnumerable<ProductsDto>>(products);

            return new BaseResponse
            {
                IsSuccess = !notificator.IsHaveNotifications(),
                StatusCode = notificator.IsHaveNotifications() ? HttpStatusCode.BadRequest : HttpStatusCode.OK,
                Errors = notificator.GetNotifications().Select(m => m.Message).ToList(),
                Result = productsDto
            };
        }

        public async Task<BaseResponse> Add(AddProductDto product)
        {
            var productEntity = mapper.Map<Product>(product);

            var isSuccessProcess = await productService.Add(productEntity);

            return new BaseResponse
            {
                IsSuccess = isSuccessProcess,
                StatusCode = !isSuccessProcess ? HttpStatusCode.BadRequest : HttpStatusCode.OK,
                Errors = notificator.GetNotifications().Select(m => m.Message).ToList(),
                Result = product
            };
        }

        public async Task<BaseResponse> Update(string sku, UpdateProductDto product)
        {
            var productEntity = mapper.Map<Product>(product);

            var isSuccessProcess = await productService.Update(sku, productEntity);

            return new BaseResponse
            {
                IsSuccess = isSuccessProcess,
                StatusCode = !isSuccessProcess ? HttpStatusCode.BadRequest : HttpStatusCode.OK,
                Errors = notificator.GetNotifications().Select(m => m.Message).ToList(),
                Result = product

            };
        }

        public async Task<BaseResponse> Remove(string sku)
        {
            var isSuccessProcess = await productService.Remove(sku);

            return new BaseResponse
            {
                IsSuccess = isSuccessProcess,
                StatusCode = !isSuccessProcess ? HttpStatusCode.BadRequest : HttpStatusCode.OK,
                Errors = notificator.GetNotifications().Select(m => m.Message).ToList()

            };
        }
    }
}

