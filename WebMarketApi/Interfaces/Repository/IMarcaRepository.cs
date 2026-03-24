using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Repository
{
    public interface IMarcaRepository
    {
        Task<IEnumerable<Marca>> GetMarcas();
        Task<Marca?> GetMarca(int id);
        Task<Marca?> GetMarca(string descripcion);
        Task<Marca> Add(Marca marca);
        Task<bool> Update(Marca marca);
        Task<bool> Delete(int id);
        Task<bool> NombreExiste(string descripcion);
    }
}
