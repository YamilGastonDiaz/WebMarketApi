using System.ComponentModel.DataAnnotations;

namespace WebMarketApi.DTOs
{
    public class UpdateProveedorDTO
    {

        [Required(ErrorMessage = "El nombre es obligatorio para actualizar")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El CUIT es obligatorio para actualizar")]
        public string? CUIT { get; set; }
        public string? Direccion { get; set; }
        public string? Telefono { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El nombre de la empresa es obligatorio para actualizar")]
        public string? Empresa { get; set; }
    }
}
