using System;
using ChallengeAutoGlass.Application.Dtos;
using ChallengeAutoGlass.Application.Responses;
using ClallangeAutoGlass.Business.Implementations.Paging;

namespace ChallengeAutoGlass.Application.AppServices.Interfaces
{
	public interface IProductAppService
	{
        Task<BaseResponse> GetAll(Pagination? pagination = null);
        Task<BaseResponse> Add(AddProductDto product);
        Task<BaseResponse> Update(string sku, UpdateProductDto product);
        Task<BaseResponse> Remove(string sku);
    }
}

