using ChallengeAutoGlass.Application.Dtos;
using ChallengeAutoGlass.Application.Responses;
using ClallangeAutoGlass.Business.Implementations.Paging;

namespace ChallengeAutoGlass.Application.AppServices.Interfaces
{
    public interface ISupplierAppService
	{
        Task<BaseResponse> GetAll(Pagination? pagination = null);
        Task<BaseResponse> Add(AddSupplierDto supplier);
        Task<BaseResponse> Update(string document, UpdateSupplierDto supplier);
        Task<BaseResponse> Remove(string document);
    }
}

