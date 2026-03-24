using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Mapping
{
    public static class ProveedorMapper
    {
        public static ProveedorDTO ToProveedorDto(this Proveedor proveedor)
        {
            return new ProveedorDTO
            {
                Proveedor_id = proveedor.Proveedor_id,
                Nombre = proveedor.Nombre,
                CUIT = proveedor.CUIT,
                Direccion = proveedor.Direccion,
                Telefono = proveedor.Telefono,
                Email = proveedor.Email,
                Empresa = proveedor.Empresa
            };
        }

        public static Proveedor ToProveedor(this CreateProveedorDTO dto)
        {
            return new Proveedor
            {
                Nombre = dto.Nombre!,
                CUIT = dto.CUIT!,
                Direccion = dto.Direccion,
                Telefono = dto.Telefono,
                Email = dto.Email,
                Empresa = dto.Empresa!
            };
        }

        public static void UpdateProveedor(this UpdateProveedorDTO dto, Proveedor proveedor)
        {
            if (dto.Nombre != null)
            {
                proveedor.Nombre = dto.Nombre;
            }

            if (dto.CUIT != null)
            {
                proveedor.CUIT = dto.CUIT;
            }

            if (dto.Direccion != null)
            {
                proveedor.Direccion = dto.Direccion;
            }

            if (dto.Telefono != null)
            {
                proveedor.Telefono = dto.Telefono;
            }

            if (dto.Email != null)
            {
                proveedor.Email = dto.Email;
            }

            if (dto.Empresa != null)
            {
                proveedor.Empresa = dto.Empresa;
            }
        }
    }
}
