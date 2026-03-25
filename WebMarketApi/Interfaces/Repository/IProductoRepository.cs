using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Repository
{
    public interface IProductoRepository
    {
        Task<(IEnumerable<Producto> productos, int total)> GetProductos(PaginacionDTO dto);
        Task<Producto?> GetProducto(int id);
        Task<Producto?> GetProducto(string descripcion);
        Task<Producto> Add(Producto producto);
        Task<bool> Update(Producto producto);
        Task<bool> Delete(int id);
        Task<bool> CodigoBarraExiste(string codigo);
    }
}
