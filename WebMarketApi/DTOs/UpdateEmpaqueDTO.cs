using System.ComponentModel.DataAnnotations;

namespace WebMarketApi.DTOs
{
    public class UpdateEmpaqueDTO
    {
        public string Descripcion { get; set; } = null!;
        public decimal CantidadUnidad { get; set; }
    }
}
