using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public interface IClienteDataProvider
    {
        Task<IEnumerable<Cliente>> GetClientes();
        Task<Cliente?> PostCliente(NuevoClienteRequest cliente);
    }
}
