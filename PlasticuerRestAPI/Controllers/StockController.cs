using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlasticuerRestAPI.DataProviders;

namespace PlasticuerRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockDataProvider stockDataProvider;

        public StockController(IStockDataProvider stockDataProvider)
        {
            this.stockDataProvider = stockDataProvider;
        }

        [HttpGet("{idArticulo}")]
        public async Task<IActionResult> Get(int idArticulo)
        {
            var stock = await this.stockDataProvider.GetStock(idArticulo);
            return Ok(new { stock });
        }
    }
}
