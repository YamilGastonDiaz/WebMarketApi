using Microsoft.EntityFrameworkCore;
using WebMarketApi.Data;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Models;

namespace WebMarketApi.Repository
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly DB_MiniMarketContext _context;

        public ProveedorRepository(DB_MiniMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Proveedor>> GetProveedores()
        {
            return await _context.Proveedores.Where(p => p.Estado).ToListAsync();
        }

        public async Task<Proveedor?> GetProveedor(int id)
        {
            return await _context.Proveedores.FirstOrDefaultAsync(p => p.Proveedor_id == id && p.Estado);
        }

        public async Task<Proveedor?> GetProveedor(string nombre)
        {
            return await _context.Proveedores.FirstOrDefaultAsync(p => p.Nombre == nombre && p.Estado);
        }

        public async Task<bool> CuitExiste(string cuit)
        {
            return await _context.Proveedores.AnyAsync(p => p.CUIT == cuit && p.Estado);
        }

        public async Task<Proveedor> Add(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();
            return proveedor;
        }

        public async Task<bool> Update(Proveedor proveedor)
        {
            _context.Proveedores.Update(proveedor);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(p => p.Proveedor_id == id && p.Estado);

            if (proveedor == null)
            {
                return false;
            }

            proveedor.Estado = false;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
