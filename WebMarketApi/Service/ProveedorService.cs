using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Mapping;

namespace WebMarketApi.Service
{
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository)
        {
            _proveedorRepository = proveedorRepository;
        }

        public async Task<IEnumerable<ProveedorDTO>> GetProveedores()
        {
            var proveedores = await _proveedorRepository.GetProveedores();

            return proveedores.Select(p => p.ToProveedorDto());
        }

        public async Task<ProveedorDTO?> GetProveedor(int id)
        {
            var proveedor = await _proveedorRepository.GetProveedor(id);

            if (proveedor == null)
            {
                return null;
            }

            return proveedor.ToProveedorDto();
        }

        public async Task<ProveedorDTO?> GetProveedor(string descripcion)
        {
            var proveedor = await _proveedorRepository.GetProveedor(descripcion);

            if (proveedor == null)
            {
                return null;
            }

            return proveedor.ToProveedorDto();
        }

        public async Task<ProveedorDTO?> Add(CreateProveedorDTO dto)
        {
            var cuitLimpio = dto.CUIT;

            if (cuitLimpio == null)
            {
                return null;
            }

            if (await _proveedorRepository.CuitExiste(cuitLimpio))
            {
                return null;
            }

            var proveedor = dto.ToProveedor();

            var nuevoProveedor = await _proveedorRepository.Add(proveedor);

            return nuevoProveedor.ToProveedorDto();
        }

        public async Task<bool> Update(int id, UpdateProveedorDTO dto)
        {
            var proveedor = await _proveedorRepository.GetProveedor(id);

            if (proveedor == null)
            {
                return false;
            }

            var nuevoCuit = dto.CUIT;

            if (nuevoCuit != null &&
                !string.Equals(proveedor.CUIT, nuevoCuit, StringComparison.OrdinalIgnoreCase))
            {
                if (await _proveedorRepository.CuitExiste(nuevoCuit))
                {
                    return false;
                }
            }

            dto.UpdateProveedor(proveedor);

            return await _proveedorRepository.Update(proveedor);
        }

        public async Task<bool> Delete(int id)
        {
            return await _proveedorRepository.Delete(id);
        }
    }
}
