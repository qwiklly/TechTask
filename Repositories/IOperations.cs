using TechTask.DTOs;
using TechTask.Models;
using static TechTask.Responses.CustomResponses;

namespace TechTask.Repositories
{
    public interface IOperations
    {
        Task<AddProductResponse> AddProductAsync(AddProductDTO model);
        Task<AddOrderResponse> AddOrderAsync(AddOrderDTO model);
        Task<DeleteProductResponse> DeleteProductAsync(int id);
        Task<DeleteOrderResponse> DeleteOrderAsync(int id);
        Task<List<GetProductsDTO>> GetProductAsync();
        Task<List<Product>> GetProductsByIdsAsync(List<int> productIds);
        Task<List<GetOrdersDTO>> GetOrderAsync();

    }
}