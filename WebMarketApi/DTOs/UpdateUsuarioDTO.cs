using WebMarketApi.Models;

namespace WebMarketApi.DTOs
{
    public class UpdateUsuarioDTO
    {
        public string Nombre { get; set; } = null!;
        public string NombreUsuario { get; set; } = null!;
        public string Contrasenia { get; set; } = null!;
        public RolUsuario rolUsuario { get; set; }
    }
}
