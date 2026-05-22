using Microsoft.AspNetCore.Mvc;
using PlasticuerRestAPI.DataProviders;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {

        private readonly IArticuloDataProvider articuloDataProvider;

        public ArticuloController(IArticuloDataProvider articuloDataProvider)
        {
            this.articuloDataProvider = articuloDataProvider;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Articulo>))]
        public async Task<IEnumerable<Articulo>> Get()
        {
            return await this.articuloDataProvider.GetArticulos();
        }

    }
}
