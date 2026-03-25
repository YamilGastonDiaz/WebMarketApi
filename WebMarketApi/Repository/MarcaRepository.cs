using Microsoft.EntityFrameworkCore;
using WebMarketApi.Data;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Models;
using WebMarketApi.Utilities;

namespace WebMarketApi.Repository
{
    public class MarcaRepository : IMarcaRepository
    {
        private readonly DB_MiniMarketContext _context;

        public MarcaRepository(DB_MiniMarketContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Marca> marcas, int total)> GetMarcas(PaginacionDTO dto)
        {
            var queryable = _context.Marcas.Where(m => m.Estado).AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(dto.Buscar))
            {
                queryable = queryable.Where(c => c.Descripcion.Contains(dto.Buscar));
            }

            var total = await queryable.CountAsync();

            var marcas = await queryable.OrderBy(m => m.Marca_id).Paginar(dto).ToListAsync();

            return (marcas, total);
        }

        public async Task<Marca?> GetMarca(int id)
        {
            return await _context.Marcas.FirstOrDefaultAsync(m => m.Marca_id == id && m.Estado);
        }

        public async Task<Marca?> GetMarca(string descripcion)
        {
            return await _context.Marcas.FirstOrDefaultAsync(m => m.Descripcion == descripcion && m.Estado);
        }

        public async Task<bool> NombreExiste(string descripcion)
        {
            return await _context.Marcas.
                AnyAsync(m => m.Descripcion == descripcion && m.Estado);
        }

        public async Task<Marca> Add(Marca marca)
        {
            _context.Marcas.Add(marca);
            await _context.SaveChangesAsync();
            return marca;
        }

        public async Task<bool> Update(Marca marca)
        {
            _context.Marcas.Update(marca);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var marca = await _context.Marcas.FirstOrDefaultAsync(m => m.Marca_id == id && m.Estado);

            if (marca == null)
            {
                return false;
            }

            marca.Estado = false;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
