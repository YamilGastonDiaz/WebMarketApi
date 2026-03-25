namespace WebMarketApi.Models
{
    public class Paginado<T>
    {
        public int TotalRegistros { get; set; }
        public int Pagina { get; set; }
        public int RecordsPorPagina { get; set; }
        public IEnumerable<T> Data { get; set; } = new List<T>();
    }
}
