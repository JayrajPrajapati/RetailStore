using Microsoft.AspNetCore.Mvc;
using Retail_Store.Models;
using Retail_Store.Services.Repository;

namespace Retail_Store.Controllers
{
    public class PricingController : Controller
    {
        private readonly RetailStore _businessLogicService;
        public PricingController(RetailStore businessLogicService)
        {
            _businessLogicService = businessLogicService;
        }
        [HttpPost]
        public IActionResult UpdatePrices([FromBody] List<CompetitorPrice> competitorPrices, [FromBody] List<DemandTrend> demandTrends)
        {
            var updatedPrices = _businessLogicService.UpdatePrices(competitorPrices, demandTrends);
            return Json(updatedPrices);
        }
    }
}
