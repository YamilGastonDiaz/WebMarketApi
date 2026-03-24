using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Mapping;

namespace WebMarketApi.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<IEnumerable<CategoriaDTO>> GetCategorias()
        {
            var categoria = await _categoriaRepository.GetCategorias();

            return categoria.Select(c => c.ToCategoriaDto());
        }

        public async Task<CategoriaDTO?> GetCategoria(int id)
        {
            var categoria = await _categoriaRepository.GetCategoria(id);

            if (categoria == null)
            {
                return null;
            }

            return categoria.ToCategoriaDto();
        }

        public async Task<CategoriaDTO?> GetCategoria(string descripcion)
        {
            var categoria = await _categoriaRepository.GetCategoria(descripcion);

            if (categoria == null)
            {
                return null;
            }

            return categoria.ToCategoriaDto();
        }

        public async Task<CategoriaDTO?> Add(CreateCategoriaDTO dto)
        {
            var categoria = dto.ToCategoria();

            if (await _categoriaRepository.NombreExiste(categoria.Descripcion))
            {
                return null;
            }

            var nuevaCategoria = await _categoriaRepository.Add(categoria);

            return nuevaCategoria.ToCategoriaDto();
        }

        public async Task<bool> Update(int id, UpdateCategoriaDTO dto)
        {
            var categoria = await _categoriaRepository.GetCategoria(id);

            if (categoria == null)
            {
                return false;
            }

            var nuevaDescripcion = dto.Descripcion;

            if (nuevaDescripcion != null &&
                !string.Equals(categoria.Descripcion, nuevaDescripcion, StringComparison.OrdinalIgnoreCase))
            {
                if (await _categoriaRepository.NombreExiste(nuevaDescripcion))
                {
                    return false;
                }
            }

            dto.UpdateCategoria(categoria);

            return await _categoriaRepository.Update(categoria);
        }

        public async Task<bool> Delete(int id)
        {
            return await _categoriaRepository.Delete(id);
        }
    }
}
