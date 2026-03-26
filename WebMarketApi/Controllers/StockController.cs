using Microsoft.AspNetCore.Mvc;
using WebMarketApi.DTOs;
using WebMarketApi.Interfaces.Service;
using WebMarketApi.Service;

namespace WebMarketApi.Controllers
{
    [ApiController]
    [Route("api/stock")]
    public class StockController : ControllerBase
    {
        private readonly IStockService _stockService;

        public StockController(IStockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("id/{id:int}")]
        public async Task<ActionResult<StockDTO>> GetProducto(int id)
        {
            var stock = await _stockService.GetStock(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, UpdateStockDTO dto)
        {
            var actualizado = await _stockService.Update(id, dto);

            if (!actualizado)
            {
                return BadRequest("Error al actualizar");
            }

            return NoContent();
        }
    }
}
