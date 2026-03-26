using Microsoft.EntityFrameworkCore;
using WebMarketApi.Data;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Models;

namespace WebMarketApi.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly DB_MiniMarketContext _context;

        public StockRepository(DB_MiniMarketContext context)
        {
            _context = context;
        }

        public async Task<StockProducto?> GetStock(int idProducto)
        {
            return await _context.StockProductos
                .Include(s => s.id_ProductoNavigation)
                .Include(s => s.id_ProductoNavigation.id_CategoriaNavigation)
                .Include(s => s.id_ProductoNavigation.id_MarcaNavigation)
                .Include(s => s.id_ProductoNavigation.id_EmpaqueNavigation)
                .FirstOrDefaultAsync(s => s.id_Producto == idProducto);
        }

        public async Task<StockProducto> Add(StockProducto stock)
        {
            _context.StockProductos.Add(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<bool> Update(StockProducto stock)
        {
            _context.StockProductos.Update(stock);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
