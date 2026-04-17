using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public interface IProvinciaDataProvider
    {
        Task<IEnumerable<Provincia>> GetProvincias();
    }
}
