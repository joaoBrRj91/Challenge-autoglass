using ChallengeAutoGlass.Application.AppServices.Interfaces;
using ChallengeAutoGlass.Application.Dtos;
using ChallengeAutoGlass.Application.Responses;
using ClallangeAutoGlass.Business.Implementations.Paging;
using Microsoft.AspNetCore.Mvc;


namespace ChallengeAutoGlass.Api.Controllers
{
    [Route("api/products")]
    public class ProductsController : MainController
    {
        private readonly IProductAppService productAppService;

        public ProductsController(IProductAppService productAppService)
        {
            this.productAppService = productAppService;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<BaseResponse>> GetAll([FromQuery] Pagination pagination)
            => CustomActionResult(await productAppService.GetAll(pagination));

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<ActionResult<BaseResponse>> Create(AddProductDto addProductDto)
            => CustomActionResult(await productAppService.Add(addProductDto));

        [HttpPut]
        [Route("{sku}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Update))]
        public async Task<ActionResult<BaseResponse>> Update([FromRoute] string sku, UpdateProductDto UpdateProductDto)
           => CustomActionResult(await productAppService.Update(sku, UpdateProductDto));

        [HttpDelete]
        [Route("{sku}")]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        public async Task<ActionResult<BaseResponse>> RemoveLogical([FromRoute]string sku)
           => CustomActionResult(await productAppService.Remove(sku));
    }
}

