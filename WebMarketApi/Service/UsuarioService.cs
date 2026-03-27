using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Repository;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Mapping;
using WebMarketApi.Models;
using WebMarketApi.Repository;

namespace WebMarketApi.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository usuarioRepository, IConfiguration configuration)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }

        public async Task<Paginado<UsuarioDTO>> GetUsuarios(PaginacionDTO dto)
        {
            var (usuario, total) = await _usuarioRepository.GetUsuarios(dto);

            return new Paginado<UsuarioDTO>
            {
                TotalRegistros = total,
                Pagina = dto.Pagina,
                RecordsPorPagina = dto.RecordPorPagina,
                Data = usuario.Select(u => u.ToUsuarioDto())
            };
        }

        public async Task<UsuarioDTO?> GetUsuario(int id)
        {
            var usuairo = await _usuarioRepository.GetUsuario(id);

            if (usuairo == null)
            {
                return null;
            }

            return usuairo.ToUsuarioDto();
        }

        public async Task<UsuarioDTO?> GetUsuario(string nombreUsuario)
        {
            var usuario = await _usuarioRepository.GetUsuario(nombreUsuario);

            if (usuario == null)
            {
                return null;
            }

            return usuario.ToUsuarioDto();
        }

        public async Task<UsuarioDTO?> Add(CreateUsuarioDTO dto)
        {
            var existe = await _usuarioRepository.GetUsuario(dto.NombreUsuario);

            if (existe != null)
            {
                return null;
            }

            var usuario = dto.ToUsuario();

            usuario.Contrasenia = BCrypt.Net.BCrypt.HashPassword(dto.Contrasenia);

            var nuevaUsuario = await _usuarioRepository.Add(usuario);

            return nuevaUsuario.ToUsuarioDto();
        }

        public async Task<bool> Update(int id, UpdateUsuarioDTO dto)
        {
            var usuario = await _usuarioRepository.GetUsuario(id);

            if (usuario == null)
            {
                return false;
            }

            if (!string.IsNullOrWhiteSpace(dto.NombreUsuario) &&
                !string.Equals(usuario.NombreUsuario, dto.NombreUsuario, StringComparison.OrdinalIgnoreCase))
            {
                if (await _usuarioRepository.GetUsuario(dto.NombreUsuario) != null)
                {
                    return false;
                }
            }

            dto.UpdateUsuario(usuario);

            if (!string.IsNullOrWhiteSpace(dto.Contrasenia))
            {
                usuario.Contrasenia = BCrypt.Net.BCrypt.HashPassword(dto.Contrasenia);
            }

            return await _usuarioRepository.Update(usuario);
        }

        public async Task<bool> Delete(int id)
        {
            return await _usuarioRepository.Delete(id);
        }

        public async Task<RespuestaAutenticacionDTO?> Login(CredencialesUsuariosDTO dto)
        {
            var usuario = await _usuarioRepository.GetUsuario(dto.NombreUsuario);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.Contrasenia, usuario.Contrasenia))
            {
                return null;
            }
            
            return GenerarToken(usuario);
        }

        private RespuestaAutenticacionDTO GenerarToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.NombreUsuario),
                new Claim(ClaimTypes.NameIdentifier, usuario.Usuario_id.ToString()),
                new Claim(ClaimTypes.Role, ((RolUsuario)usuario.Rol).ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddHours(8);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims,
                expires: expiracion,
                signingCredentials: creds
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return new RespuestaAutenticacionDTO
            {
                Token = tokenString,
                Expiracion = expiracion
            };
        }
    }
}

