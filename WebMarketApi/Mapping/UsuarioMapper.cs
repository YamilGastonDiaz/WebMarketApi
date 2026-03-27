using WebMarketApi.DTOs;
using WebMarketApi.Models;

namespace WebMarketApi.Mapping
{
    public static class UsuarioMapper
    {
        public static UsuarioDTO ToUsuarioDto(this Usuario usuario)
        {
            return new UsuarioDTO
            {
                Usuario_id = usuario.Usuario_id,
                Nombre = usuario.Nombre,
                NombreUsuario = usuario.NombreUsuario,
                Contrasenia = usuario.Contrasenia,
                rolUsuario = (RolUsuario)usuario.Rol
            };
        }

        public static Usuario ToUsuario(this CreateUsuarioDTO dto)
        {
            return new Usuario
            {
                Nombre = dto.Nombre,
                NombreUsuario = dto.NombreUsuario,
                Contrasenia = dto.Contrasenia,
                Rol = (int)dto.rolUsuario
            };
        }

        public static void UpdateUsuario(this UpdateUsuarioDTO dto, Usuario usuario)
        {
            if (dto.Nombre != null)
            {
                usuario.Nombre = dto.Nombre;
            }

            if (dto.NombreUsuario != null)
            {
                usuario.NombreUsuario = dto.NombreUsuario;
            }

            if (dto.Contrasenia != null)
            {
                usuario.Contrasenia = dto.Contrasenia;
            }

            if (dto.rolUsuario != 0)
            {
                usuario.Rol = (int)dto.rolUsuario;
            }
        }
    }
}
