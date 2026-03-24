using WebMarketApi.DTOs;

namespace WebMarketApi.Interfaces.Service
{
    public interface IMarcaService
    {
        Task<IEnumerable<MarcaDTO>> GetMarcas();
        Task<MarcaDTO?> GetMarca(int id);
        Task<MarcaDTO?> GetMarca(string descripcion);
        Task<MarcaDTO?> Add(CreateMarcaDTO dto);
        Task<bool> Update(int id, UpdateMarcaDTO dto);
        Task<bool> Delete(int id);
    }
}
