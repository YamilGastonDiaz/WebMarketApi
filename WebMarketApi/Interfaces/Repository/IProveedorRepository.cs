using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Repository
{
    public interface IProveedorRepository
    {
        Task<(IEnumerable<Proveedor> proveedores, int total)> GetProveedores(PaginacionDTO dto);
        Task<Proveedor?> GetProveedor(int id);
        Task<Proveedor?> GetProveedor(string cuit);
        Task<Proveedor> Add(Proveedor proveedor);
        Task<bool> Update(Proveedor proveedor);
        Task<bool> Delete(int id);
        Task<bool> CuitExiste(string cuit);
    }
}
