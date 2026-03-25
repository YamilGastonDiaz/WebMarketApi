using Microsoft.EntityFrameworkCore;
using WebMarketApi.Data;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Models;
using WebMarketApi.Utilities;

namespace WebMarketApi.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DB_MiniMarketContext _context;

        public ProductoRepository(DB_MiniMarketContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Producto> productos, int total)> GetProductos(PaginacionDTO dto)
        {
            var queryable = _context.Productos.Where(p => p.Estado)
                .Include(p => p.id_CategoriaNavigation)
                .Include(p => p.id_MarcaNavigation)
                .Include(p => p.id_EmpaqueNavigation)
                .Include(p => p.StockProductos)
                .AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(dto.Buscar))
            {
                queryable = queryable.Where(p => p.Descripcion.Contains(dto.Buscar));
            }

            var total = await queryable.CountAsync();

            var productos = await queryable.OrderBy(p => p.Producto_id).Paginar(dto).ToListAsync();

            return (productos, total);
        }

        public async Task<Producto?> GetProducto(int id)
        {
            return await _context.Productos
                .Include(p => p.id_CategoriaNavigation)
                .Include(p => p.id_MarcaNavigation)
                .Include(p => p.id_EmpaqueNavigation)
                .Include(p => p.StockProductos)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Producto_id == id && p.Estado);
        }

        public async Task<Producto?> GetProducto(string descripcion)
        {
            return await _context.Productos
                .Include(p => p.id_CategoriaNavigation)
                .Include(p => p.id_MarcaNavigation)
                .Include(p => p.id_EmpaqueNavigation)
                .Include(p => p.StockProductos)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Descripcion == descripcion && p.Estado);
        }

        public async Task<bool> CodigoBarraExiste(string codigo)
        {
            return await _context.Productos
                .AnyAsync(p => p.CodigoBarras == codigo && p.Estado);
        }

        public async Task<Producto> Add(Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return producto;
        }

        public async Task<bool> Update(Producto producto)
        {
            _context.Productos.Update(producto);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var producto = await _context.Productos
                .FirstOrDefaultAsync(p => p.Producto_id == id && p.Estado);

            if (producto == null)
            {
                return false;
            }

            producto.Estado = false;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
