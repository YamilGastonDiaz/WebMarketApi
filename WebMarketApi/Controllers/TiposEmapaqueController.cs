using Microsoft.AspNetCore.Mvc;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Service;

namespace WebMarketApi.Controllers
{
    [ApiController]
    [Route("api/tiposEmpaque")]
    public class TiposEmapaqueController : ControllerBase
    {
        private readonly ITiposEmpaqueService _empaqueService;

        public TiposEmapaqueController(ITiposEmpaqueService empaqueService)
        {
            _empaqueService = empaqueService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpaqueDTO>>> GetEmpaques()
        {
            var empaques = await _empaqueService.GetTiposEmpaques();

            return Ok(empaques);
        }

        [HttpGet("id/{id:int}", Name = "ObtenerEmpaque")]
        public async Task<ActionResult<EmpaqueDTO>> GetEmpaque(int id)
        {
            var empaque = await _empaqueService.GetTiposEmpaque(id);

            if (empaque == null)
            {
                return NotFound();
            }

            return Ok(empaque);
        }

        [HttpGet("nombre/{descripcion}")]
        public async Task<ActionResult<EmpaqueDTO>> GetEmpaque(string descripcion)
        {
            var empaque = await _empaqueService.GetTiposEmpaque(descripcion);

            if (empaque == null)
            {
                return NotFound();
            }

            return Ok(empaque);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateEmpaqueDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empaque = await _empaqueService.Add(dto);

            if (empaque == null)
            {
                return BadRequest("El tipo de empaque ya existe");
            }

            return CreatedAtRoute("ObtenerEmpaque", new { id = empaque.Empaque_id }, empaque);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UpdateEmpaqueDTO dto)
        {
            var actualizado = await _empaqueService.Update(id, dto);

            if (!actualizado)
            {
                return BadRequest("Error al actualizar");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _empaqueService.Delete(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
