using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Service
{
    public interface IUsuarioService
    {
        Task<Paginado<UsuarioDTO>> GetUsuarios(PaginacionDTO dto);
        Task<UsuarioDTO?> GetUsuario(int id);
        Task<UsuarioDTO?> GetUsuario(string nombreUsuario);
        Task<UsuarioDTO?> Add(CreateUsuarioDTO dto);
        Task<bool> Update(int id, UpdateUsuarioDTO dto);
        Task<bool> Delete(int id);
        Task<RespuestaAutenticacionDTO?> Login(CredencialesUsuariosDTO dto);
    }
}
