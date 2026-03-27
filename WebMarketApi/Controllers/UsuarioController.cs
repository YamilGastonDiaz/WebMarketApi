using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Models;
using WebMarketApi.Service;

namespace WebMarketApi.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        
        [HttpGet]
        public async Task<ActionResult<Paginado<UsuarioDTO>>> GetUsuarios([FromQuery] PaginacionDTO dto)
        {
            var usuarios = await _usuarioService.GetUsuarios(dto);

            return Ok(usuarios);
        }

        [HttpGet("id/{id:int}", Name = "ObtenerUsuario")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            var usuario = await _usuarioService.GetUsuario(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpGet("nombre/{nombreUsuario}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(string nombreUsuario)
        {
            var usuario = await _usuarioService.GetUsuario(nombreUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateUsuarioDTO dto)
        {
            var usuario = await _usuarioService.Add(dto);

            if (usuario == null)
            {
                return BadRequest("El usuario ya existe");
            }

            return CreatedAtRoute("ObtenerUsuario", new { id = usuario.Usuario_id }, usuario);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UpdateUsuarioDTO dto)
        {
            var actualizado = await _usuarioService.Update(id, dto);

            if (!actualizado)
            {
                return BadRequest("Error al actualizar");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _usuarioService.Delete(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
        

        [HttpPost("login")]
        public async Task<ActionResult<RespuestaAutenticacionDTO>> Login(CredencialesUsuariosDTO dto)
        {
            var resultado = await _usuarioService.Login(dto);

            if (resultado == null)
            {
                return Unauthorized("Login incorrecto");
            }

            return Ok(resultado);
        }
    }
}
