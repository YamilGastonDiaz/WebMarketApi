using Microsoft.AspNetCore.Mvc;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Service;

namespace WebMarketApi.Controllers
{
    [ApiController]
    [Route("api/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias([FromQuery] PaginacionDTO dto)
        {
            var categorias = await _categoriaService.GetCategorias(dto);

            return Ok(categorias);
        }

        [HttpGet("id/{id:int}", Name = "ObtenerCategoria")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoria(int id)
        {
            var categoria = await _categoriaService.GetCategoria(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpGet("nombre/{descripcion}")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoria(string descripcion)
        {
            var categoria = await _categoriaService.GetCategoria(descripcion);

            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateCategoriaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var categoria = await _categoriaService.Add(dto);

            if (categoria == null)
            {
                return BadRequest("La Categoria ya existe");
            }

            return CreatedAtRoute("ObtenerCategoria", new { id = categoria.Categoria_id }, categoria);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UpdateCategoriaDTO dto)
        {
            var actualizado = await _categoriaService.Update(id, dto);

            if (!actualizado)
            {
                return BadRequest("Error al actualizar");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _categoriaService.Delete(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
