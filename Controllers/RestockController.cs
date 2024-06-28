using Microsoft.AspNetCore.Mvc;
using Retail_Store.Context;
using Retail_Store.Services.Repository;

namespace Retail_Store.Controllers
{
    public class RestockController : Controller
    {
        private readonly RetailStore _businessLogicService;
        private readonly RetailStoreContext _context;
        public RestockController(RetailStore businessLogicService, RetailStoreContext context)
        {
            _businessLogicService = businessLogicService;
            _context = context;
        }
        public IActionResult Index()
        {
            var salesData = _context.Sales.ToList();
            var restockPlan = _businessLogicService.GenerateRestockPlan(salesData);
            return Json(restockPlan);
        }
    }
}
