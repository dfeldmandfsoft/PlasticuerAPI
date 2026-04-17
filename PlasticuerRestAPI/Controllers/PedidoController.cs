using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PlasticuerRestAPI.DataProviders;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {

        private readonly IPedidoDataProvider pedidoDataProvider;

        public PedidoController(IPedidoDataProvider pedidoDataProvider)
        {
            this.pedidoDataProvider = pedidoDataProvider;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Pedido pedido)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this.pedidoDataProvider.PostPedido(pedido);
            return Ok();
        }

    }
}
