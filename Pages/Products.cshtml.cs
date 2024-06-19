using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTask.DTOs;
using TechTask.Repositories;

namespace TechTask.Pages
{
    public class ProductsModel(IOperations operations) : PageModel
    {
        private readonly IOperations _operations = operations;

        public List<GetProductsDTO> Products { get; set; }

        public async Task OnGetAsync()
        {
            Products = await _operations.GetProductAsync();
        }

        public async Task<IActionResult> OnPostAddProductAsync(string name, decimal price)
        {
            var response = await _operations.AddProductAsync(new AddProductDTO { Name = name, Price = price });
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteProductAsync(DeleteProductDTO model)
        {
            var response = await _operations.DeleteProductAsync(model);
            return RedirectToPage();
        }
    }
}
