using Microsoft.AspNetCore.Mvc;
using PlasticuerRestAPI.DataProviders;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CondicionIvaController : ControllerBase
    {
        private readonly ICondicionIvaDataProvider _condicionIvaDataProvider;

        public CondicionIvaController(ICondicionIvaDataProvider condicionIvaDataProvider)
        {
            _condicionIvaDataProvider = condicionIvaDataProvider;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<CondicionIva>))]
        public async Task<IEnumerable<CondicionIva>> Get()
        {
            return await _condicionIvaDataProvider.GetCondicionesIva();
        }
    }
}
