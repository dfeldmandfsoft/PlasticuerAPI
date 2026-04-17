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
            using (_dbConnection)
            {
                return await _dbConnection.QueryAsync<Cliente>(
                    "exec API.spClientes",
                    commandType: CommandType.Text);
            }
        }

        public async Task<Cliente?> PostCliente(NuevoClienteRequest cliente)
        {
            using (_dbConnection)
            {
                return await _dbConnection.QueryFirstOrDefaultAsync<Cliente>(
                    @"exec API.spAltaCliente @Nombre, @Direccion, @IdProvincia, @IdLocalidad,
                                             @CPA, @Telefono, @Mail, @IdCondicionIva, @CuitDni",
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
                    commandType: CommandType.Text);
            }
        }
    }
}
