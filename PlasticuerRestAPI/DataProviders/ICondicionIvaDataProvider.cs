using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public interface ICondicionIvaDataProvider
    {
        Task<IEnumerable<CondicionIva>> GetCondicionesIva();
        Task<CondicionIva?> GetCondicionIva(int idCondicionIva);
    }
}
