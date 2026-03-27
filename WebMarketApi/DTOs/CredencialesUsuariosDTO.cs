using System.ComponentModel.DataAnnotations;
using WebMarketApi.Models;

namespace WebMarketApi.DTOs
{
    public class CredencialesUsuariosDTO
    {
        [Required]
        public string NombreUsuario { get; set; } = null!;
        [Required]
        public string Contrasenia { get; set; } = null!;
    }
}
