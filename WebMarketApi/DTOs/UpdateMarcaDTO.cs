using System.ComponentModel.DataAnnotations;

namespace WebMarketApi.DTOs
{
    public class UpdateMarcaDTO
    {
        [Required(ErrorMessage = "La descripción es obligatoria para actualizar")]
        public string Descripcion { get; set; } = null!;
    }
}
