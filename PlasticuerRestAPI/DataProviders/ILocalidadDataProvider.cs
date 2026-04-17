using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public interface ILocalidadDataProvider
    {
        Task<IEnumerable<Localidad>> GetLocalidades(int idProvincia);
    }
}
