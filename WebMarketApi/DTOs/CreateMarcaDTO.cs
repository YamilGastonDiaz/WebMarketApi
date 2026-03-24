using System.ComponentModel.DataAnnotations;

namespace WebMarketApi.DTOs
{
    public class CreateMarcaDTO
    {
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; } = null!;
    }
}
