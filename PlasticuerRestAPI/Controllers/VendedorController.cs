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
    public class VendedorController : ControllerBase
    {

        private readonly IVendedorDataProvider vendedorDataProvider;

        public VendedorController(IVendedorDataProvider vendedorDataProvider)
        {
            this.vendedorDataProvider = vendedorDataProvider;
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<Vendedor>))]
        public async Task<IEnumerable<Vendedor>> Get()
        {
            return await this.vendedorDataProvider.GetVendedores();
        }

    }
}
