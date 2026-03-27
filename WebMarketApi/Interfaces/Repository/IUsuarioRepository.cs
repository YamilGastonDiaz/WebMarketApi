using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Repository
{
    public interface IUsuarioRepository
    {
        Task<(IEnumerable<Usuario> usuarios, int total)> GetUsuarios(PaginacionDTO dto);
        Task<Usuario?> GetUsuario(int id);
        Task<Usuario?> GetUsuario(string nombreUsuario);
        Task<Usuario> Add(Usuario usuario);
        Task<bool> Update(Usuario usuario);
        Task<bool> Delete(int id);
    }
}
