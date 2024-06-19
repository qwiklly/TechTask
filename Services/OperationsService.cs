using TechTask.DTOs;
using static TechTask.Responses.CustomResponses;

namespace TechTask.Services
{
    public class OperationsService : IOperationsService
    {
        private readonly HttpClient _httpClient;

        public OperationsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Operations/AddProduct", model);
            var result = await response.Content.ReadFromJsonAsync<AddProductResponse>();
            return result!;
        }

        public async Task<AddOrderResponse> AddOrderAsync(AddOrderDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("api/Operations/AddOrder", model);
            var result = await response.Content.ReadFromJsonAsync<AddOrderResponse>();
            return result!;
        }

        public async Task<DeleteProductResponse> DeleteProductAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Operations/DeleteProduct/{id}");
            var result = await response.Content.ReadFromJsonAsync<DeleteProductResponse>();
            return result!;
        }

        public async Task<DeleteOrderResponse> DeleteOrderAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"api/Operations/DeleteOrder/{id}");
            var result = await response.Content.ReadFromJsonAsync<DeleteOrderResponse>();
            return result!;
        }
    }
}
