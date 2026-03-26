using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Mapping
{
    public static class ProductoMapper
    {
        public static ProductoDTO ToProductoDto(this Producto producto)
        {
            return new ProductoDTO
            {
                Producto_id = producto.Producto_id,
                CodigoBarras = producto.CodigoBarras,

                NombreCategoria = producto.id_CategoriaNavigation?.Descripcion,
                NombreMarca = producto.id_MarcaNavigation?.Descripcion,
                NombreEmpaque = producto.id_EmpaqueNavigation?.Descripcion,

                Descripcion = producto.Descripcion,
                Stock_min = producto.Stock_min
            };
        }

        public static Producto ToProducto(this CreateProductoDTO dto)
        {
            return new Producto
            {
                CodigoBarras = dto.CodigoBarras,
                id_Categoria = dto.id_Categoria,
                id_Marca = dto.id_Marca,
                id_Empaque = dto.id_Empaque,
                Descripcion = dto.Descripcion,
                Stock_min = dto.Stock_min
            };
        }

        public static void UpdateProducto(this UpdateProductoDTO dto, Producto producto)
        {
            if (dto.CodigoBarras != null)
            {
                producto.CodigoBarras = dto.CodigoBarras;
            }

            if (dto.id_Categoria != 0)
            {
                producto.id_Categoria = dto.id_Categoria;
            }

            if (dto.id_Marca != 0)
            {
                producto.id_Marca = dto.id_Marca;
            }

            if (dto.id_Empaque != 0)
            {
                producto.id_Empaque = dto.id_Empaque;
            }

            if (dto.Descripcion != null)
            {
                producto.Descripcion = dto.Descripcion;
            }

            if (dto.Stock_min > 0)
            {
                producto.Stock_min = dto.Stock_min;
            }
        }
    }
}
