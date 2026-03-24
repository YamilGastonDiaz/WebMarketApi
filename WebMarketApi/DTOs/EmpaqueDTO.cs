namespace WebMarketApi.DTOs
{
    public class EmpaqueDTO
    {
        public int Empaque_id { get; set; }

        public string Descripcion { get; set; } = null!;

        public decimal CantidadUnidad { get; set; }
    }
}
