using Retail_Store.Models;
using Retail_Store.Services.Interface;

namespace Retail_Store.Services.Repository
{
    public class RetailStore :IRetailStore
    {
        public List<RestockRecommendation> GenerateRestockPlan(List<Sale> salesData)
        {
            var salesSummary = salesData
                .GroupBy(s => s.ProductID)
                .Select(g => new
                {
                    ProductID = g.Key,
                    TotalSold = g.Sum(s => s.QuantitySold)
                })
                .ToList();

            var restockPlan = salesSummary
                .Select(s => new RestockRecommendation
                {
                    ProductID = s.ProductID,
                    RecommendedQuantity = s.TotalSold * 2 // Simple heuristic: reorder double the sold quantity
                })
                .ToList();

            return restockPlan;
        }

        public List<PriceUpdate> UpdatePrices(List<CompetitorPrice> competitorPrices, List<DemandTrend> demandTrends)
        {
            var updatedPrices = competitorPrices.Join(demandTrends,
                cp => cp.ProductID,
                dt => dt.ProductID,
                (cp, dt) => new
                {
                    cp.ProductID,
                    cp.Price,
                    dt.Trend
                })
                .Select(p => new PriceUpdate
                {
                    ProductID = p.ProductID,
                    UpdatedPrice = p.Trend switch
                    {
                        "increasing" => p.Price * 1.10m, // Increase price by 10%
                        "decreasing" => p.Price * 0.90m, // Decrease price by 10%
                        _ => p.Price
                    }
                })
                .ToList();

            return updatedPrices;
        }

        public List<InventoryAdjustment> OptimizeInventory(List<PopularityData> popularityData, List<ShelfLifeData> shelfLifeData, List<CurrentInventory> currentInventory)
        {
            var inventoryOptimization = currentInventory
                .Join(popularityData,
                    ci => ci.ProductID,
                    pd => pd.ProductID,
                    (ci, pd) => new { ci.ProductID, ci.CurrentStock, pd.PopularityScore })
                .Join(shelfLifeData,
                    temp => temp.ProductID,
                    sld => sld.ProductID,
                    (temp, sld) => new
                    {
                        temp.ProductID,
                        temp.CurrentStock,
                        temp.PopularityScore,
                        sld.ShelfLife
                    })
                .Select(i => new InventoryAdjustment
                {
                    ProductID = i.ProductID,
                    RecommendedAdjustment = (int)(i.PopularityScore * i.ShelfLife) - i.CurrentStock
                })
                .ToList();

            return inventoryOptimization;
        }
    }
}
