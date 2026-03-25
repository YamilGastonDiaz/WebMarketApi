namespace WebMarketApi.DTOs
{
    public class ProductoDTO
    {
        public int Producto_id { get; set; }
        public string CodigoBarras { get; set; } = null!;
        // Nombres para mostrar en la tabla/interfaz
        public string? NombreCategoria { get; set; }
        public string? NombreMarca { get; set; }
        public string? NombreEmpaque { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal? Stock_min { get; set; }
        public StockDTO StockDTO { get; set; } = new StockDTO();
    }
}
