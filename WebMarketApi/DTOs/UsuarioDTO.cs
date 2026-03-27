using WebMarketApi.Models;

namespace WebMarketApi.DTOs
{
    public class UsuarioDTO
    {
        public int Usuario_id { get; set; }
        public string Nombre { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public RolUsuario rolUsuario { get; set; }
    }
}
