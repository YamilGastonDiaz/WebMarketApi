using Microsoft.EntityFrameworkCore;
using WebMarketApi.Data;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Models;
using WebMarketApi.Utilities;

namespace WebMarketApi.Repository
{
    public class TiposEmpaqueRepository : ITiposEmpaqueRepository
    {
        private readonly DB_MiniMarketContext _context;

        public TiposEmpaqueRepository(DB_MiniMarketContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<TiposEmpaque> empaques, int total)> GetTiposEmpaques(PaginacionDTO dto)
        {
            var queryable = _context.TiposEmpaques.Where(e => e.Estado).AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(dto.Buscar))
            {
                queryable = queryable.Where(e => e.Descripcion.Contains(dto.Buscar));
            }

            var total = await queryable.CountAsync();

            var empaques = await queryable.OrderBy(e => e.Empaque_id).Paginar(dto).ToListAsync();

            return (empaques, total);
        }

        public async Task<TiposEmpaque?> GetTiposEmpaque(int id)
        {
            return await _context.TiposEmpaques.FirstOrDefaultAsync(e => e.Empaque_id == id && e.Estado);
        }

        public async Task<TiposEmpaque?> GetTiposEmpaque(string descripcion)
        {
            return await _context.TiposEmpaques.FirstOrDefaultAsync(e => e.Descripcion == descripcion && e.Estado);
        }

        public async Task<bool> NombreExiste(string descripcion)
        {
            return await _context.TiposEmpaques.
                AnyAsync(e => e.Descripcion == descripcion && e.Estado);
        }

        public async Task<TiposEmpaque> Add(TiposEmpaque empaque)
        {
            _context.TiposEmpaques.Add(empaque);
            await _context.SaveChangesAsync();
            return empaque;
        }

        public async Task<bool> Update(TiposEmpaque empaque)
        {
            _context.TiposEmpaques.Update(empaque);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var empaque = await _context.TiposEmpaques.FirstOrDefaultAsync(e => e.Empaque_id == id && e.Estado);

            if (empaque == null)
            {
                return false;
            }

            empaque.Estado = false;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
