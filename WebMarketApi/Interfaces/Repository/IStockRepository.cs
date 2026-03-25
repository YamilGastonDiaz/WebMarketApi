using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Repository
{
    public interface IStockRepository
    {
        Task<StockProducto?> GetStock(int id);
        Task<StockProducto> Add(StockProducto stock);
        Task<bool> Update(StockProducto stock);
    }
}
