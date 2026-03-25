using Microsoft.AspNetCore.Mvc;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Models;
using WebMarketApi.Service;

namespace WebMarketApi.Controllers
{
    [ApiController]
    [Route("api/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet]
        public async Task<ActionResult<Paginado<ProductoDTO>>> GetCategorias([FromQuery] PaginacionDTO dto)
        {
            var categorias = await _productoService.GetProductos(dto);

            return Ok(categorias);
        }

        [HttpGet("id/{id:int}", Name = "ObtenerProducto")]
        public async Task<ActionResult<ProductoDTO>> GetProducto(int id)
        {
            var producto = await _productoService.GetProducto(id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpGet("nombre/{descripcion}")]
        public async Task<ActionResult<ProductoDTO>> GetProducto(string descripcion)
        {
            var producto = await _productoService.GetProducto(descripcion);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateProductoDTO dto)
        {
            var producto = await _productoService.Add(dto);

            if (producto == null)
            {
                return BadRequest("El Producto ya existe");
            }

            return CreatedAtRoute("ObtenerProducto", new { id = producto.Producto_id }, producto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UpdateProductoDTO dto)
        {
            var actualizado = await _productoService.Update(id, dto);

            if (!actualizado)
            {
                return BadRequest("Error al actualizar");
            }

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var eliminado = await _productoService.Delete(id);

            if (!eliminado)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
