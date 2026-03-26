using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Mapping;

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
            {
                return null;
            }

            return stock.ToStockDto();
        }

        public async Task<bool> Update(int idProducto, UpdateStockDTO dto)
        {
            var stock = await _stockRepository.GetStock(idProducto);

            if (stock == null)
            {
                return false;
            }

            dto.UpdateStock(stock);

            return await _stockRepository.Update(stock);
        }
    }
}
