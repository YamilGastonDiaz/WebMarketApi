using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Service
{
    public interface IProveedorService
    {
        Task<Paginado<ProveedorDTO>> GetProveedores(PaginacionDTO dto);
        Task<ProveedorDTO?> GetProveedor(int id);
        Task<ProveedorDTO?> GetProveedor(string cuit);
        Task<ProveedorDTO?> Add(CreateProveedorDTO dto);
        Task<bool> Update(int id, UpdateProveedorDTO dto);
        Task<bool> Delete(int id);
    }
}
