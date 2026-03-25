using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Repository
{
    public interface ITiposEmpaqueRepository
    {
        Task<(IEnumerable<TiposEmpaque> empaques, int total)> GetTiposEmpaques(PaginacionDTO dto);
        Task<TiposEmpaque?> GetTiposEmpaque(int id);
        Task<TiposEmpaque?> GetTiposEmpaque(string descripcion);
        Task<TiposEmpaque> Add(TiposEmpaque empaque);
        Task<bool> Update(TiposEmpaque empaque);
        Task<bool> Delete(int id);
        Task<bool> NombreExiste(string descripcion);
    }
}
