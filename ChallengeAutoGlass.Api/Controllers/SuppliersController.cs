﻿using ChallengeAutoGlass.Application.AppServices.Interfaces;
using ChallengeAutoGlass.Application.Dtos.Creates;
using ChallengeAutoGlass.Application.Responses;
using ClallangeAutoGlass.Business.Implementations.Paging;
using Microsoft.AspNetCore.Mvc;


namespace ChallengeAutoGlass.Api.Controllers
{
    [Route("api/suppliers")]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierAppService supplierAppService;

        public SuppliersController(ISupplierAppService supplierAppService)
        {
            this.supplierAppService = supplierAppService;
        }

        [HttpGet]
        public async Task<BaseResponse> GetAll([FromQuery] Pagination pagination)
            => await supplierAppService.GetAll(pagination);

        [HttpPost]
        public async Task<BaseResponse> Create(AddSupplierDto addSupplierDto)
            => await supplierAppService.Add(addSupplierDto);

        [HttpPut]
        [Route("{document}")]
        public async Task<BaseResponse> Update([FromRoute] string document,UpdateSupplierDto updateSupplierDto)
           => await supplierAppService.Update(document, updateSupplierDto);

        [HttpPatch]
        [Route("disable/{document}")]
        public async Task<BaseResponse> RemoveLogical([FromRoute]string document)
           => await supplierAppService.Remove(document);
    }
}

