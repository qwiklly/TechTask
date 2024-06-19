using Microsoft.EntityFrameworkCore;
using TechTask.Data;
using TechTask.DTOs;
using TechTask.Models;
using static TechTask.Responses.CustomResponses;

namespace TechTask.Repositories
{
    public class Operations : IOperations
    {
        private readonly AppDbContext _appDbContext;

        public Operations(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        // Метод для добавления товара
        public async Task<AddProductResponse> AddProductAsync(AddProductDTO model)
        {
            _appDbContext.Product.Add(new Product
            {
                Name = model.Name,
                Price = model.Price
            });

            await _appDbContext.SaveChangesAsync();

            return new AddProductResponse(true, "Product added successfully");
        }

        // Метод для получения товара по идентификаторам
        public async Task<List<Product>> GetProductsByIdsAsync(List<int> productIds)
        {
            return await _appDbContext.Product
                .Where(p => productIds.Contains(p.Id))
                .ToListAsync();
        }

        // Метод для добавления заказа
        public async Task<AddOrderResponse> AddOrderAsync(AddOrderDTO model)
        {
            try
            {
                var products = await GetProductsByIdsAsync(model.ProductIds);

                var order = new Order
                {
                    OrderDate = model.OrderDate,
                    Products = products
                };

                _appDbContext.Order.Add(order);
                await _appDbContext.SaveChangesAsync();

                return new AddOrderResponse(true, "Order added successfully");
            }
            catch (Exception ex)
            {
                return new AddOrderResponse(false, $"Failed to add order: {ex.Message}");
            }
        }

        // Метод для удаления товара
        public async Task<DeleteProductResponse> DeleteProductAsync(int id)
        {
            var product = await _appDbContext.Product.FindAsync(id);
            if (product == null)
                return new DeleteProductResponse(false, "Product not found");

            _appDbContext.Product.Remove(product);
            await _appDbContext.SaveChangesAsync();

            return new DeleteProductResponse(true, "Product deleted successfully");
        }

        // Метод для удаления заказа
        public async Task<DeleteOrderResponse> DeleteOrderAsync(int id)
        {
            var order = await _appDbContext.Order.Include(o => o.Products)
            .FirstOrDefaultAsync(o => o.Id == id);

            if (order == null)
                return new DeleteOrderResponse(false, "Order not found");

            // Удаление связанных продуктов
            _appDbContext.Product.RemoveRange(order.Products);

            // Удаление заказа
            _appDbContext.Order.Remove(order);

            await _appDbContext.SaveChangesAsync();

            return new DeleteOrderResponse(true, "Order deleted successfully");
        }

        // Метод для получения товара
        public async Task<List<GetProductsDTO>> GetProductAsync()
        {
            return await _appDbContext.Product
               .Select(u => new GetProductsDTO
               {
                   ProductId = u.Id,
                   Name = u.Name,
                   Price = u.Price,
               })
               .ToListAsync();
        }

        // Метод для получения заказа
        public async Task<List<GetOrdersDTO>> GetOrderAsync()
        {
            return await _appDbContext.Order
               .Select(u => new GetOrdersDTO
               {
                   OrderId = u.Id,
                   Products = u.Products,
                   OrderDate = u.OrderDate,
               })
               .ToListAsync();
        }
    }
}
