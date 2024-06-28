using Microsoft.AspNetCore.Mvc;
using Retail_Store.Models;
using Retail_Store.Services.Repository;

namespace Retail_Store.Controllers
{
    public class InventoryController : Controller
    {
        private readonly RetailStore _businessLogicService;

        public InventoryController(RetailStore businessLogicService)
        {
            _businessLogicService = businessLogicService;
        }
        [HttpPost]
        public IActionResult OptimizeInventory([FromBody] List<PopularityData> popularityData, [FromBody] List<ShelfLifeData> shelfLifeData, [FromBody] List<CurrentInventory> currentInventory)
        {
            var inventoryOptimization = _businessLogicService.OptimizeInventory(popularityData, shelfLifeData, currentInventory);
            return Json(inventoryOptimization);
        }
    }
}
