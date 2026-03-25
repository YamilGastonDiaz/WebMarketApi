namespace WebMarketApi.DTOs
{
    public record PaginacionDTO(int Pagina = 1, int RecordPorPagina = 10, string? Buscar = null)
    {
        private const int CantidadMaximaPorPagina = 50;

        public int Pagina { get; init; } = Math.Max(1, Pagina);
        public int RecordPorPagina { get; init; } = Math.Clamp(RecordPorPagina, 1, CantidadMaximaPorPagina);
        public string? Buscar { get; init; } = Buscar?.Trim();
    }
}
