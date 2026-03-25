using Microsoft.AspNetCore.Mvc;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Service;

namespace WebMarketApi.Controllers
{
    [ApiController]
    [Route("api/marca")]
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService _marcaService;

        public MarcaController(IMarcaService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MarcaDTO>>> GetMarcas()
        {
            var marcas = await _marcaService.GetMarcas();

            return Ok(marcas);
        }

        [HttpGet("id/{id:int}", Name = "ObtenerMarca")]
        public async Task<ActionResult<MarcaDTO>> GetMarca(int id)
        {
            var marca = await _marcaService.GetMarca(id);

            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        [HttpGet("nombre/{descripcion}")]
        public async Task<ActionResult<MarcaDTO>> GetMarca(string descripcion)
        {
            var marca = await _marcaService.GetMarca(descripcion);

            if (marca == null)
            {
                return NotFound();
            }

            return Ok(marca);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateMarcaDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var marca = await _marcaService.Add(dto);

            if (marca == null)
            {
                return BadRequest("La Marca ya existe");
            }

            return CreatedAtRoute("ObtenerMarca", new { id = marca.Marca_id }, marca);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UpdateMarcaDTO dto)
        {
            var actualizado = await _marcaService.Update(id, dto);

            if (!actualizado)
            {
                return BadRequest("Error al actualizar");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _marcaService.Delete(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
