using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Mapping;

namespace WebMarketApi.Service
{
    public class TiposEmpaqueService : ITiposEmpaqueService
    {
        private readonly ITiposEmpaqueRepository _tiposEmpaqueRepository;

        public TiposEmpaqueService(ITiposEmpaqueRepository tiposEmpaqueRepository)
        {
            _tiposEmpaqueRepository = tiposEmpaqueRepository;
        }

        public async Task<IEnumerable<EmpaqueDTO>> GetTiposEmpaques()
        {
            var empaque = await _tiposEmpaqueRepository.GetTiposEmpaques();

            return empaque.Select(e => e.ToEmapaqueDto());
        }

        public async Task<EmpaqueDTO?> GetTiposEmpaque(int id)
        {
            var empaque = await _tiposEmpaqueRepository.GetTiposEmpaque(id);

            if (empaque == null)
            {
                return null;
            }

            return empaque.ToEmapaqueDto();
        }

        public async Task<EmpaqueDTO?> GetTiposEmpaque(string descripcion)
        {
            var empaque = await _tiposEmpaqueRepository.GetTiposEmpaque(descripcion);

            if (empaque == null)
            {
                return null;
            }

            return empaque.ToEmapaqueDto();
        }

        public async Task<EmpaqueDTO?> Add(CreateEmpaqueDTO dto)
        {
            var tiposEmpaque = dto.ToEmpaque();

            if (await _tiposEmpaqueRepository.NombreExiste(tiposEmpaque.Descripcion))
            {
                return null;
            }

            var nuevoEmpaque = await _tiposEmpaqueRepository.Add(tiposEmpaque);

            return nuevoEmpaque.ToEmapaqueDto();
        }

        public async Task<bool> Update(int id, UpdateEmpaqueDTO dto)
        {
            var tiposEmpaque = await _tiposEmpaqueRepository.GetTiposEmpaque(id);

            if (tiposEmpaque == null)
            {
                return false;
            }

            if (dto.CantidadUnidad <= 0)
            {
                return false;
            }

            var nuevaDescripcion = dto.Descripcion;

            if (nuevaDescripcion != null &&
                !string.Equals(tiposEmpaque.Descripcion, nuevaDescripcion, StringComparison.OrdinalIgnoreCase))
            {
                if (await _tiposEmpaqueRepository.NombreExiste(nuevaDescripcion))
                {
                    return false;
                }
            }

            dto.UpdateEmpaque(tiposEmpaque);

            return await _tiposEmpaqueRepository.Update(tiposEmpaque);
        }

        public async Task<bool> Delete(int id)
        {
            return await _tiposEmpaqueRepository.Delete(id);
        }
    }
}
