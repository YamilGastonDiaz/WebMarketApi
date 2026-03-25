using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Repository
{
    public interface IMarcaRepository
    {
        Task<(IEnumerable<Marca> marcas, int total)> GetMarcas(PaginacionDTO dto);
        Task<Marca?> GetMarca(int id);
        Task<Marca?> GetMarca(string descripcion);
        Task<Marca> Add(Marca marca);
        Task<bool> Update(Marca marca);
        Task<bool> Delete(int id);
        Task<bool> NombreExiste(string descripcion);
    }
}
