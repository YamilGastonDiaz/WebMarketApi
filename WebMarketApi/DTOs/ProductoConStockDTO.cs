namespace WebMarketApi.DTOs
{
    public class ProductoConStockDTO
    {
        public string CodigoBarras { get; set; } = null!;
        // Nombres para mostrar en la tabla/interfaz
        public string? NombreCategoria { get; set; }
        public string? NombreMarca { get; set; }
        public string? NombreEmpaque { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal? Stock_min { get; set; }
    }
}
