using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TechTask.DTOs;
using TechTask.Repositories;
using static TechTask.Responses.CustomResponses;

namespace TechTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController(IOperations accountrepo) : ControllerBase
    {
        private readonly IOperations accountrepo = accountrepo;


        [HttpPost("AddProduct")]
        [SwaggerOperation(Summary = "Добавить новый продукт", Description = "Метод необходим для добавления нового продукта.")]
        public async Task<ActionResult<AddProductResponse>> AddProductAsync(AddProductDTO model)
        {
            var result = await accountrepo.AddProductAsync(model);
            return Ok(result);
        }

        [HttpPost("AddOrder")]
        [SwaggerOperation(Summary = "Заказать новый продукт", Description = "Метод необходим для заказа нового продукта.")]
        public async Task<ActionResult<AddOrderResponse>> AddOrderAsync(AddOrderDTO model)
        {
            var result = await accountrepo.AddOrderAsync(model);
            return Ok(result);
        }

        [HttpDelete("DeleteProduct/{id}")]
        [SwaggerOperation(Summary = "Удалить новый продукт", Description = "Метод необходим для удаления нового продукта.")]
        public async Task<ActionResult<DeleteProductResponse>> DeleteProductAsync(int id)
        {
            var result = await accountrepo.DeleteProductAsync(id);
            return Ok(result);
        }

        [HttpDelete("DeleteOrder/{id}")]
        [SwaggerOperation(Summary = "Отменить заказ", Description = "Метод необходим отмены заказа.")]
        public async Task<ActionResult<DeleteOrderResponse>> DeleteOrderAsync(int id)
        {
            var result = await accountrepo.DeleteOrderAsync(id);
            return Ok(result);
        }
    }
}