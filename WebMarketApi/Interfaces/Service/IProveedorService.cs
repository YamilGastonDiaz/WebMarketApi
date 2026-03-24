using WebMarketApi.DTOs;

namespace WebMarketApi.Interfaces.Service
{
    public interface IProveedorService
    {
        Task<IEnumerable<ProveedorDTO>> GetProveedores();
        Task<ProveedorDTO?> GetProveedor(int id);
        Task<ProveedorDTO?> GetProveedor(string cuit);
        Task<ProveedorDTO?> Add(CreateProveedorDTO dto);
        Task<bool> Update(int id, UpdateProveedorDTO dto);
        Task<bool> Delete(int id);
    }
}
