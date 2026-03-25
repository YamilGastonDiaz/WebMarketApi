using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Service
{
    public interface IMarcaService
    {
        Task<Paginado<MarcaDTO>> GetMarcas(PaginacionDTO dto);
        Task<MarcaDTO?> GetMarca(int id);
        Task<MarcaDTO?> GetMarca(string descripcion);
        Task<MarcaDTO?> Add(CreateMarcaDTO dto);
        Task<bool> Update(int id, UpdateMarcaDTO dto);
        Task<bool> Delete(int id);
    }
}
