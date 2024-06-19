namespace TechTask.Responses
{
    public class CustomResponses
    {
        public record AddProductResponse(bool Flag = false, string Message = null!);
        public record AddOrderResponse(bool Flag = false, string Message = null!);
        public record DeleteProductResponse(bool Flag = false, string Message = null!);
        public record DeleteOrderResponse(bool Flag = false, string Message = null!);
       
    }
}
