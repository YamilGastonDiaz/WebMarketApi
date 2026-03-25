using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Interfaces.Service;

namespace WebMarketApi.Service
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        public async Task<StockDTO?> GetStock(int idProducto)
        {
            var stock = await _stockRepository.GetStock(idProducto);

            if (stock == null)
                return null;

            return new StockDTO
            {
                Stock_id = stock.Stock_id,
                id_Producto = stock.id_Producto,
                Stock_actual = stock.Stock_actual,
                PrecioDia = stock.PrecioDia,
                PrecioNoche = stock.PrecioNoche
            };
        }

        public async Task<bool> Update(int idProducto, UpdateStockDTO dto)
        {
            var stock = await _stockRepository.GetStock(idProducto);

            if (stock == null)
                return false;

            stock.Stock_actual = dto.Stock_actual;
            stock.PrecioDia = dto.PrecioDia;
            stock.PrecioNoche = dto.PrecioNoche;

            return await _stockRepository.Update(stock);
        }
    }
}
