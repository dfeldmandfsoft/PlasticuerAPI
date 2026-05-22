using Dapper;
using System.Data;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public class ClienteDataProvider : IClienteDataProvider
    {
        private readonly IDbConnection _dbConnection;

        public ClienteDataProvider(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Cliente>> GetClientes()
        {
            return await _dbConnection.QueryAsync<Cliente>(
                "API.spClientes",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<Cliente?> PostCliente(NuevoClienteRequest cliente)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<Cliente>(
                "API.spAltaCliente",
                new
                {
                    cliente.Nombre,
                    cliente.Direccion,
                    cliente.IdProvincia,
                    cliente.IdLocalidad,
                    cliente.CPA,
                    cliente.Telefono,
                    cliente.Mail,
                    cliente.IdCondicionIva,
                    cliente.CuitDni
                },
                commandType: CommandType.StoredProcedure);
        }
    }
}
