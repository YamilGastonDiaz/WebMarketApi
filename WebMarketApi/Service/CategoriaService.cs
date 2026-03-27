using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Mapping;
using WebMarketApi.Models;

namespace WebMarketApi.Service
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<Paginado<CategoriaDTO>> GetCategorias(PaginacionDTO dto)
        {
            var (categoria, total) = await _categoriaRepository.GetCategorias(dto);

            return new Paginado<CategoriaDTO>
            {
                TotalRegistros = total,
                Pagina = dto.Pagina,
                RecordsPorPagina = dto.RecordPorPagina,
                Data = categoria.Select(c => c.ToCategoriaDto())
            };
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

            if (!string.IsNullOrWhiteSpace(dto.Descripcion) &&
                !string.Equals(categoria.Descripcion, dto.Descripcion, StringComparison.OrdinalIgnoreCase))
            {
                if (await _categoriaRepository.NombreExiste(dto.Descripcion))
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
