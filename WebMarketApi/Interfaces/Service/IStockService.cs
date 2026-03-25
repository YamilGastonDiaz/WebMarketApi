using WebMarketApi.DTOs;

namespace WebMarketApi.Interfaces.Service
{
    public interface IStockService
    {
        Task<StockDTO?> GetStock(int idProducto);
        Task<bool> Update(int idProducto, UpdateStockDTO dto);
    }
}
