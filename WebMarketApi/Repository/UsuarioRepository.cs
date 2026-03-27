using Microsoft.EntityFrameworkCore;
using WebMarketApi.Data;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Models;
using WebMarketApi.Utilities;

namespace WebMarketApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DB_MiniMarketContext _context;

        public UsuarioRepository(DB_MiniMarketContext context)
        {
            _context = context;
        }

        public async Task<(IEnumerable<Usuario> usuarios, int total)> GetUsuarios(PaginacionDTO dto)
        {
            var queryable = _context.Usuarios.Where(u => u.Estado).AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(dto.Buscar))
            {
                queryable = queryable.Where(u => u.Nombre.Contains(dto.Buscar));
            }

            var total = await queryable.CountAsync();

            var usuario = await queryable.OrderBy(u => u.Usuario_id).Paginar(dto).ToListAsync();

            return (usuario, total);
        }

        public async Task<Usuario?> GetUsuario(int id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Usuario_id == id && u.Estado);
        }

        public async Task<Usuario?> GetUsuario(string nombreUsuario)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && u.Estado);
        }

        public async Task<Usuario> Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            return usuario;
        }

        public async Task<bool> Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Usuario_id == id && u.Estado);

            if (usuario == null)
            {
                return false;
            }

            usuario.Estado = false;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
