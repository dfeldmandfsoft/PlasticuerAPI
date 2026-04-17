using System.Collections.Generic;
using System.Threading.Tasks;
using PlasticuerAPI.Models;

namespace PlasticuerAPI.DataProviders
{
    public interface IArticuloDataProvider
    {
        Task<IEnumerable<Articulo>> GetArticulos();

    }
}
