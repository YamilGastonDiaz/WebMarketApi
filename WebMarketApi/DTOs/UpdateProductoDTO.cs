namespace WebMarketApi.DTOs
{
    public class UpdateProductoDTO
    {
        public string CodigoBarras { get; set; } = null!;
        public int id_Categoria { get; set; }
        public int id_Marca { get; set; }
        public int id_Empaque { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal? Stock_min { get; set; }
    }
}
