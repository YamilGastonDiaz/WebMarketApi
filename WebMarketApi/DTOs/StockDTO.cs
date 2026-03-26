namespace WebMarketApi.DTOs
{
    public class StockDTO : ProductoConStockDTO
    {
        public int Stock_id { get; set; }
        public int id_Producto { get; set; }
        public decimal? Stock_actual { get; set; }
        public decimal? PrecioDia { get; set; }
        public decimal? PrecioNoche { get; set; }
    }
}
