using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Service
{
    public interface ITiposEmpaqueService
    {
        Task<Paginado<EmpaqueDTO>> GetTiposEmpaques(PaginacionDTO dto);
        Task<EmpaqueDTO?> GetTiposEmpaque(int id);
        Task<EmpaqueDTO?> GetTiposEmpaque(string descripcion);
        Task<EmpaqueDTO?> Add(CreateEmpaqueDTO dto);
        Task<bool> Update(int id, UpdateEmpaqueDTO dto);
        Task<bool> Delete(int id);
    }
}
