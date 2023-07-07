using AutoMapper;
using ChallengeAutoGlass.Application.AppServices.Interfaces;
using ChallengeAutoGlass.Application.Responses;
using Microsoft.AspNetCore.Mvc;


namespace ChallengeAutoGlass.Api.Controllers
{
    [Route("api/[controller]")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierAppService supplierAppService;

        public SuppliersController(ISupplierAppService supplierAppService)
        {
            this.supplierAppService = supplierAppService;
        }

        [HttpGet]
        public async Task<BaseResponse> GetAll()
        {
            return await supplierAppService.GetAll();
        }
    }
}

