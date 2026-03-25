using Microsoft.AspNetCore.Mvc;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Models;

namespace WebMarketApi.Controllers
{
    [ApiController]
    [Route("api/proveedor")]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet]
        public async Task<ActionResult<Paginado<ProveedorDTO>>> GetProveedores([FromQuery] PaginacionDTO dto)
        {
            var proveedores = await _proveedorService.GetProveedores(dto);

            return Ok(proveedores);
        }

        [HttpGet("id/{id:int}", Name = "ObtenerProveedor")]
        public async Task<ActionResult<ProveedorDTO>> GetProveedor(int id)
        {
            var proveedor = await _proveedorService.GetProveedor(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        [HttpGet("nombre/{descripcion}")]
        public async Task<ActionResult<ProveedorDTO>> GetProveedor(string descripcion)
        {
            var proveedor = await _proveedorService.GetProveedor(descripcion);

            if (proveedor == null)
            {
                return NotFound();
            }

            return Ok(proveedor);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateProveedorDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var proveedor = await _proveedorService.Add(dto);

            if (proveedor == null)
            {
                return BadRequest("El proveedor ya existe");
            }

            return CreatedAtRoute("ObtenerProveedor", new { id = proveedor.Proveedor_id }, proveedor);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UpdateProveedorDTO dto)
        {
            var actualizado = await _proveedorService.Update(id, dto);

            if (!actualizado)
            {
                return BadRequest("Error al actualizar");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _proveedorService.Delete(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
