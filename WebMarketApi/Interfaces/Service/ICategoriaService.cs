using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Interfaces.Service
{
    public interface ICategoriaService
    {
        Task<Paginado<CategoriaDTO>> GetCategorias(PaginacionDTO dto);
        Task<CategoriaDTO?> GetCategoria(int id);
        Task<CategoriaDTO?> GetCategoria(string descripcion);
        Task<CategoriaDTO?> Add(CreateCategoriaDTO dto);
        Task<bool> Update(int id, UpdateCategoriaDTO dto);
        Task<bool> Delete(int id);
    }
}
