using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Mapping;

namespace WebMarketApi.Service
{
    public class MarcaService : IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public async Task<IEnumerable<MarcaDTO>> GetMarcas()
        {
            var marcas = await _marcaRepository.GetMarcas();

            return marcas.Select(m => m.ToMarcaDto());
        }

        public async Task<MarcaDTO?> GetMarca(int id)
        {
            var marca = await _marcaRepository.GetMarca(id);

            if (marca == null)
            {
                return null;
            }

            return marca.ToMarcaDto();
        }

        public async Task<MarcaDTO?> GetMarca(string descripcion)
        {
            var marca = await _marcaRepository.GetMarca(descripcion);

            if (marca == null)
            {
                return null;
            }

            return marca.ToMarcaDto();
        }

        public async Task<MarcaDTO?> Add(CreateMarcaDTO dto)
        {
            var marca = dto.ToMarca();

            if (await _marcaRepository.NombreExiste(marca.Descripcion))
            {
                return null;
            }

            var nuevaMarca = await _marcaRepository.Add(marca);

            return nuevaMarca.ToMarcaDto();
        }

        public async Task<bool> Update(int id, UpdateMarcaDTO dto)
        {
            var marca = await _marcaRepository.GetMarca(id);

            if (marca == null)
            {
                return false;
            }

            var nuevaDescripcion = dto.Descripcion;

            if (nuevaDescripcion != null &&
                !string.Equals(marca.Descripcion, nuevaDescripcion, StringComparison.OrdinalIgnoreCase))
            {
                if (await _marcaRepository.NombreExiste(nuevaDescripcion))
                {
                    return false;
                }
            }

            dto.UpdateMarca(marca);

            return await _marcaRepository.Update(marca);
        }

        public async Task<bool> Delete(int id)
        {
            return await _marcaRepository.Delete(id);
        }
    }
}
