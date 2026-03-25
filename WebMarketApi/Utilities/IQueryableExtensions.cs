using WebMarketApi.DTOs;

namespace WebMarketApi.Utilities
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginar<T>(this IQueryable<T> queryable, PaginacionDTO dto) 
        {
            return queryable
                .Skip((dto.Pagina - 1) * dto.RecordPorPagina)
                .Take(dto.RecordPorPagina);
        }
    }
}
