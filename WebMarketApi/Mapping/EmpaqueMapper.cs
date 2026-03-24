using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Mapping
{
    public static class EmpaqueMapper
    {
        public static EmpaqueDTO ToEmapaqueDto(this TiposEmpaque empaque)
        {
            return new EmpaqueDTO
            {
                Empaque_id = empaque.Empaque_id,
                Descripcion = empaque.Descripcion,
                CantidadUnidad = empaque.CantidadUnidad
            };
        }

        public static TiposEmpaque ToEmpaque(this CreateEmpaqueDTO dto)
        {
            return new TiposEmpaque
            {
                Descripcion = dto.Descripcion,
                CantidadUnidad = dto.CantidadUnidad
            };
        }

        public static void UpdateEmpaque(this UpdateEmpaqueDTO dto, TiposEmpaque empaque)
        {
            if (dto.Descripcion != null)
            {
                empaque.Descripcion = dto.Descripcion;
            }

            if (dto.CantidadUnidad > 0)
            {
                empaque.CantidadUnidad = dto.CantidadUnidad;
            }
        }
    }
}
