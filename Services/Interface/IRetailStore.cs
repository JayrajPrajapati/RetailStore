using Retail_Store.Models;

namespace Retail_Store.Services.Interface
{
    public interface IRetailStore
    {
        public List<RestockRecommendation> GenerateRestockPlan(List<Sale> salesData);
        public List<PriceUpdate> UpdatePrices(List<CompetitorPrice> competitorPrices, List<DemandTrend> demandTrends);
        public List<InventoryAdjustment> OptimizeInventory(List<PopularityData> popularityData, List<ShelfLifeData> shelfLifeData, List<CurrentInventory> currentInventory);
    }
}
