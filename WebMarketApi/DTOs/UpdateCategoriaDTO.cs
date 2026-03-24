using System.ComponentModel.DataAnnotations;

namespace WebMarketApi.DTOs
{
    public class UpdateCategoriaDTO
    {
        [Required(ErrorMessage = "La descripción es obligatoria para actualizar")]
        public string Descripcion { get; set; } = null!;
    }
}
