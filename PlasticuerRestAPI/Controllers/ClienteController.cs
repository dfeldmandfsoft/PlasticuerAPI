using Microsoft.AspNetCore.Mvc;
using PlasticuerRestAPI.DataProviders;
using PlasticuerRestAPI.Helpers;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteDataProvider _clienteDataProvider;
        private readonly ICondicionIvaDataProvider _condicionIvaDataProvider;

        public ClienteController(IClienteDataProvider clienteDataProvider, ICondicionIvaDataProvider condicionIvaDataProvider)
        {
            _clienteDataProvider = clienteDataProvider;
            _condicionIvaDataProvider = condicionIvaDataProvider;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Cliente>))]
        public async Task<IEnumerable<Cliente>> Get()
        {
            return await _clienteDataProvider.GetClientes();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NuevoClienteRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var condicion = await _condicionIvaDataProvider.GetCondicionIva(request.IdCondicionIva);
            if (condicion == null)
                return BadRequest(new { error = "La condición de IVA indicada no existe." });

            if (condicion.RequiereCuit)
            {
                if (!DocumentoValidator.ValidarCuit(request.CuitDni!))
                    return BadRequest(new { error = "El CUIT ingresado no es válido." });
            }
            else
            {
                if (!DocumentoValidator.ValidarDni(request.CuitDni!))
                    return BadRequest(new { error = "El DNI debe contener al menos 6 dígitos numéricos." });
            }

            var clienteCreado = await _clienteDataProvider.PostCliente(request);

            if (clienteCreado == null || clienteCreado.IdCliente == 0)
                return StatusCode(500, new { error = "No se pudo dar de alta el cliente." });

            return Ok(clienteCreado);
        }
    }
}
