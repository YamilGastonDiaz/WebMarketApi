namespace WebMarketApi.DTOs
{
    public class UpdateStockDTO
    {
        public decimal? Stock_actual { get; set; }
        public decimal? PrecioDia { get; set; }
        public decimal? PrecioNoche { get; set; }
    }
}
