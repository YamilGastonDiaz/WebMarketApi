using System.ComponentModel.DataAnnotations;

namespace WebMarketApi.DTOs
{
    public class CreateProveedorDTO
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El CUIT es obligatorio")]
        public string? CUIT { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El nombre de la empresa es obligatorio")]
        public string? Empresa { get; set; }
    }
}
