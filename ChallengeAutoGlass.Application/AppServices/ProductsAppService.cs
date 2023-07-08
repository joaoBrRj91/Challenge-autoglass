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
    public class ProductsAppService : BaseAppService, IProductAppService
    {
        private readonly IProductService productService;
        private readonly INotificator notificator;
        private readonly IMapper mapper;

        public ProductsAppService(IProductService productService,
            INotificator notificator, IMapper mapper) : base(notificator)
        {
            this.productService = productService;
            this.notificator = notificator;
            this.mapper = mapper;
        }

        public async Task<BaseResponse> GetAll(Pagination? pagination = null)
        {
            var products = await productService.GetAll(pagination);

            var productsDto = mapper.Map<IEnumerable<ProductDto>>(products);
            

            return CreateResponseResultByStatusCode(HttpStatusCode.OK, productsDto);
        }

        public async Task<BaseResponse> Add(AddProductDto product)
        {
            var productEntity = mapper.Map<Product>(product);

            await productService.Add(productEntity);

            return CreateResponseResultByStatusCode(HttpStatusCode.Created, product);
        }

        public async Task<BaseResponse> Update(string sku, UpdateProductDto product)
        {
            var productEntity = mapper.Map<Product>(product);

            await productService.Update(sku, productEntity);

            return CreateResponseResultByStatusCode(HttpStatusCode.NoContent, product);
        }

        public async Task<BaseResponse> Remove(string sku)
        {
            await productService.Remove(sku);

            return CreateResponseResultByStatusCode(HttpStatusCode.OK, sku);

        }
    }
}

