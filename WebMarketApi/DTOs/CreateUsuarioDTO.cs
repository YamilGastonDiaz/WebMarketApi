using System.ComponentModel.DataAnnotations;
using WebMarketApi.Models;

namespace WebMarketApi.DTOs
{
    public class CreateUsuarioDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string NombreUsuario { get; set; } = null!;
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Contrasenia { get; set; } = null!;
        [Required(ErrorMessage = "El rol de usuario es obligatoria")]
        public RolUsuario rolUsuario { get; set; }
    }
}
