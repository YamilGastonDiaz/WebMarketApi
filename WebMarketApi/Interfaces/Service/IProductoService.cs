using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Service
{
    public interface IProductoService
    {
        Task<Paginado<ProductoDTO>> GetProductos(PaginacionDTO dto);
        Task<ProductoDTO?> GetProducto(int id);
        Task<ProductoDTO?> GetProducto(string descripcion);
        Task<ProductoDTO?> Add(CreateProductoDTO dto);
        Task<bool> Update(int id, UpdateProductoDTO dto);
        Task<bool> Delete(int id);
    }
}
