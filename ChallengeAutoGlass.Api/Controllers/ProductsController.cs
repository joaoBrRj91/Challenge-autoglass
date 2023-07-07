using ChallengeAutoGlass.Application.AppServices.Interfaces;
using ChallengeAutoGlass.Application.Dtos.Creates;
using ChallengeAutoGlass.Application.Responses;
using ClallangeAutoGlass.Business.Implementations.Paging;
using Microsoft.AspNetCore.Mvc;


namespace ChallengeAutoGlass.Api.Controllers
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductAppService productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        [HttpGet]
        public async Task<BaseResponse> GetAll([FromQuery] Pagination pagination)
            => await productAppService.GetAll(pagination);

        [HttpPost]
        public async Task<BaseResponse> Create(AddProductDto addProductDto)
            => await productAppService.Add(addProductDto);

        [HttpPut]
        [Route("{sku}")]
        public async Task<BaseResponse> Update([FromRoute] string sku, UpdateProductDto UpdateProductDto)
           => await productAppService.Update(sku, UpdateProductDto);

        [HttpPatch]
        [Route("disable/{sku}")]
        public async Task<BaseResponse> RemoveLogical([FromRoute]string sku)
           => await productAppService.Remove(sku);
    }
}

