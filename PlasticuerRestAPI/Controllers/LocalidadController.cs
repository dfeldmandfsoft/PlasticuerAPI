using Microsoft.AspNetCore.Mvc;
using PlasticuerRestAPI.DataProviders;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : ControllerBase
    {
        private readonly ILocalidadDataProvider _localidadDataProvider;

        public LocalidadController(ILocalidadDataProvider localidadDataProvider)
        {
            _localidadDataProvider = localidadDataProvider;
        }

        [HttpGet("{idProvincia}")]
        [Produces(typeof(IEnumerable<Localidad>))]
        public async Task<IEnumerable<Localidad>> Get(int idProvincia)
        {
            return await _localidadDataProvider.GetLocalidades(idProvincia);
        }
    }
}
