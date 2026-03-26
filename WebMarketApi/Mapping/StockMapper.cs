using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Mapping
{
    public static class StockMapper
    {
        public static StockDTO ToStockDto(this StockProducto stock)
        {
            return new StockDTO
            {
                Stock_id = stock.Stock_id,
                id_Producto = stock.id_Producto,
                Stock_actual = stock.Stock_actual,
                PrecioDia = stock.PrecioDia,
                PrecioNoche = stock.PrecioNoche,

                CodigoBarras = stock.id_ProductoNavigation.CodigoBarras,
                Descripcion = stock.id_ProductoNavigation.Descripcion,
                NombreCategoria = stock.id_ProductoNavigation.id_CategoriaNavigation?.Descripcion,
                NombreMarca = stock.id_ProductoNavigation.id_MarcaNavigation?.Descripcion,
                NombreEmpaque = stock.id_ProductoNavigation.id_EmpaqueNavigation?.Descripcion,
                Stock_min  = stock.id_ProductoNavigation.Stock_min
            };
        }

        public static void UpdateStock(this UpdateStockDTO dto, StockProducto stock)
        {
            if (dto.PrecioDia != 0)
            {
                stock.PrecioDia = dto.PrecioDia;
            }

            if (dto.PrecioNoche != 0)
            {
                stock.PrecioNoche = dto.PrecioNoche;
            }
        }
    }
}
