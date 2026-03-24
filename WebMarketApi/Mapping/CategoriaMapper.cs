using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Mapping
{
    public static class CategoriaMapper
    {
        public static CategoriaDTO ToCategoriaDto(this Categoria categoria)
        {
            return new CategoriaDTO
            {
                Categoria_id = categoria.Categoria_id,
                Descripcion = categoria.Descripcion
            };
        }

        public static Categoria ToCategoria(this CreateCategoriaDTO dto)
        {
            return new Categoria
            {
                Descripcion = dto.Descripcion
            };
        }

        public static void UpdateCategoria(this UpdateCategoriaDTO dto, Categoria categoria)
        {
            if(dto.Descripcion != null)
            {
                categoria.Descripcion = dto.Descripcion;
            }
        }
    }
}
