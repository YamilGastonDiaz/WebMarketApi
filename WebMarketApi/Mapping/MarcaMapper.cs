using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Mapping
{
    public static class MarcaMapper
    {
        public static MarcaDTO ToMarcaDto(this Marca marca)
        {
            return new MarcaDTO
            {
                Marca_id = marca.Marca_id,
                Descripcion = marca.Descripcion
            };
        }

        public static Marca ToMarca(this CreateMarcaDTO dto)
        {
            return new Marca
            {
                Descripcion = dto.Descripcion
            };
        }

        public static void UpdateMarca(this UpdateMarcaDTO dto, Marca marca)
        {
            if (dto.Descripcion != null)
            {
                marca.Descripcion = dto.Descripcion;
            }
        }
    }
}
