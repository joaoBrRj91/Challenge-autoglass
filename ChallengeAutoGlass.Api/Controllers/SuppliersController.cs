using ChallengeAutoGlass.Application.AppServices.Interfaces;
using ChallengeAutoGlass.Application.Dtos.Creates;
using ChallengeAutoGlass.Application.Responses;
using ClallangeAutoGlass.Business.Implementations.Paging;
using Microsoft.AspNetCore.Mvc;


namespace ChallengeAutoGlass.Api.Controllers
{
    [Route("api/suppliers")]
    public class SuppliersController : MainController
    {
        private readonly ISupplierAppService supplierAppService;

        public SuppliersController(ISupplierAppService supplierAppService)
        {
            this.supplierAppService = supplierAppService;
        }

        [HttpGet]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Get))]
        public async Task<ActionResult<BaseResponse>> GetAll([FromQuery] Pagination pagination)
            => CustomActionResult(await supplierAppService.GetAll(pagination));

        [HttpPost]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Create))]
        public async Task<ActionResult<BaseResponse>> Create(AddSupplierDto addSupplierDto)
            => CustomActionResult(await supplierAppService.Add(addSupplierDto));

        [HttpPut]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Update))]
        [Route("{document}")]
        public async Task<ActionResult<BaseResponse>> Update([FromRoute] string document,UpdateSupplierDto updateSupplierDto)
           => CustomActionResult(await supplierAppService.Update(document, updateSupplierDto));

        [HttpDelete]
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Delete))]
        [Route("{document}")]
        public async Task<ActionResult<BaseResponse>> RemoveLogical([FromRoute]string document)
           => CustomActionResult(await supplierAppService.Remove(document));
    }
}

