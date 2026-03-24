using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Repository
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> GetCategorias();
        Task<Categoria?> GetCategoria(int id);
        Task<Categoria?> GetCategoria(string descripcion);
        Task<Categoria> Add(Categoria categoria);
        Task<bool> Update(Categoria categoria);
        Task<bool> Delete(int id);
        Task<bool> NombreExiste(string descripcion);
    }
}
