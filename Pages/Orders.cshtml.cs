using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TechTask.DTOs;
using TechTask.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TechTask.Pages
{
    public class OrdersModel(IOperations operations) : PageModel
    {
        private readonly IOperations _operations = operations;

        public List<GetOrdersDTO> Orders { get; set; }
        public List<GetProductsDTO> Products { get; set; }

        public async Task OnGetAsync()
        {
            Orders = await _operations.GetOrderAsync();
            Products = await _operations.GetProductAsync();
        }

        public async Task<IActionResult> OnPostAddOrderAsync(List<int> productIds)
        {
            var utcNow = DateTime.UtcNow;

            // Перевод времени в московское время
            var moscowTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
            var moscowTime = TimeZoneInfo.ConvertTimeFromUtc(utcNow, moscowTimeZone);

            await _operations.AddOrderAsync(new AddOrderDTO
            {
                ProductIds = productIds,
                OrderDate = moscowTime
            });

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteOrderAsync(int id)
        {
            await _operations.DeleteOrderAsync(id);

            return RedirectToPage();
        }
    }
}
