using System.ComponentModel.DataAnnotations;

namespace WebMarketApi.DTOs
{
    public class CreateProductoDTO
    {
        [Required(ErrorMessage = "El codigo de barras es obligatorio")]
        public string CodigoBarras { get; set; } = null!;
        [Required(ErrorMessage = "La categoria es obligatoria")]
        public int id_Categoria { get; set; }
        [Required(ErrorMessage = "La marca es obligatoria")]
        public int id_Marca { get; set; }
        [Required(ErrorMessage = "El empaque es obligatorio")]
        public int id_Empaque { get; set; }
        [Required(ErrorMessage = "La descripcion es obligatoria")]
        public string Descripcion { get; set; } = null!;
        public decimal? Stock_min { get; set; }
    }
}
