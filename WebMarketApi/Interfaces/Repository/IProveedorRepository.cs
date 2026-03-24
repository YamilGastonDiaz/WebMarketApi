using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Repository
{
    public interface IProveedorRepository
    {
        Task<IEnumerable<Proveedor>> GetProveedores();
        Task<Proveedor?> GetProveedor(int id);
        Task<Proveedor?> GetProveedor(string cuit);
        Task<Proveedor> Add(Proveedor proveedor);
        Task<bool> Update(Proveedor proveedor);
        Task<bool> Delete(int id);
        Task<bool> CuitExiste(string cuit);
    }
}
