using TechTask.DTOs;
using static TechTask.Responses.CustomResponses;

namespace TechTask.Services
{
    public interface IOperationsService
    {
        Task<AddProductResponse> AddProductAsync(AddProductDTO model);
        Task<AddOrderResponse> AddOrderAsync(AddOrderDTO model);
        Task<DeleteOrderResponse> DeleteOrderAsync(int id);
        Task<DeleteProductResponse> DeleteProductAsync(int id);
    }
}
