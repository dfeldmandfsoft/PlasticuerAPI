using Microsoft.AspNetCore.Mvc;
using PlasticuerRestAPI.DataProviders;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaDataProvider _provinciaDataProvider;

        public ProvinciaController(IProvinciaDataProvider provinciaDataProvider)
        {
            _provinciaDataProvider = provinciaDataProvider;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Provincia>))]
        public async Task<IEnumerable<Provincia>> Get()
        {
            return await _provinciaDataProvider.GetProvincias();
        }
    }
}
