using System.ComponentModel.DataAnnotations;

namespace WebMarketApi.DTOs
{
    public class UpdateEmpaqueDTO
    {
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; } = null!;
        [Range(0.01, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public decimal CantidadUnidad { get; set; }
    }
}
