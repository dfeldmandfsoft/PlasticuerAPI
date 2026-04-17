using System.Collections.Generic;
using System.Threading.Tasks;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public interface IArticuloDataProvider
    {
        Task<IEnumerable<Articulo>> GetArticulos();

    }
}
