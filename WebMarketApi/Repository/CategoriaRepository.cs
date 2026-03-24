using Microsoft.EntityFrameworkCore;
using WebMarketApi.Data;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Models;

namespace WebMarketApi.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly DB_MiniMarketContext _context;

        public CategoriaRepository(DB_MiniMarketContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> GetCategorias()
        {
            return await _context.Categorias.Where(c => c.Estado).ToListAsync();
        }

        public async Task<Categoria?> GetCategoria(int id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Categoria_id == id && c.Estado);
        }

        public async Task<Categoria?> GetCategoria(string descripcion)
        {
            return await _context.Categorias.FirstOrDefaultAsync(c => c.Descripcion == descripcion && c.Estado);
        }

        public async Task<bool> NombreExiste(string descripcion)
        {
            return await _context.Categorias.
                AnyAsync(c => c.Descripcion == descripcion && c.Estado);
        }

        public async Task<Categoria> Add(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> Update(Categoria categoria)
        {
            _context.Categorias.Update(categoria);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var categoria = await _context.Categorias.
                FirstOrDefaultAsync(c => c.Categoria_id == id && c.Estado);

            if (categoria == null)
            {
                return false;
            }

            categoria.Estado = false;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
