using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Mapping;
using WebMarketApi.Models;

namespace WebMarketApi.Service
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IStockRepository _stockRepository;

        public ProductoService(IProductoRepository productoRepository, IStockRepository stockRepository)
        {
            _productoRepository = productoRepository;
            _stockRepository = stockRepository;
        }

        public async Task<Paginado<ProductoDTO>> GetProductos(PaginacionDTO dto)
        {
            var (productos, total) = await _productoRepository.GetProductos(dto);

            return new Paginado<ProductoDTO>
            {
                TotalRegistros = total,
                Pagina = dto.Pagina,
                RecordsPorPagina = dto.RecordPorPagina,
                Data = productos.Select(p => p.ToProductoDto())
            };
        }

        public async Task<ProductoDTO?> GetProducto(int id)
        {
            var producto = await _productoRepository.GetProducto(id);

            if (producto == null)
            {
                return null;
            }

            return producto.ToProductoDto();
        }

        public async Task<ProductoDTO?> GetProducto(string descripcion)
        {
            var producto = await _productoRepository.GetProducto(descripcion);

            if (producto == null)
            {
                return null;
            }

            return producto.ToProductoDto();
        }

        public async Task<ProductoDTO?> Add(CreateProductoDTO dto)
        {

            if (await _productoRepository.CodigoBarraExiste(dto.CodigoBarras))
            {
                return null;
            }

            var producto = dto.ToProducto();

            var nuevoProducto = await _productoRepository.Add(producto);

            var stock = new StockProducto
            {
                id_Producto = nuevoProducto.Producto_id,
                Stock_actual = 0,
                PrecioDia = 0,
                PrecioNoche = 0,
            };

            await _stockRepository.Add(stock);

            var productoCompleto = await _productoRepository.GetProducto(nuevoProducto.Producto_id);

            return productoCompleto?.ToProductoDto();
        }

        public async Task<bool> Update(int id, UpdateProductoDTO dto)
        {
            var producto = await _productoRepository.GetProducto(id);

            if (producto == null)
                return false;

            if (!string.Equals(producto.CodigoBarras, dto.CodigoBarras, StringComparison.OrdinalIgnoreCase))
            {
                if (await _productoRepository.CodigoBarraExiste(dto.CodigoBarras))
                {
                    return false;
                }
            }

            dto.UpdateProducto(producto);

            return await _productoRepository.Update(producto);
        }

        public async Task<bool> Delete(int id)
        {
            return await _productoRepository.Delete(id);
        }
    }
}
