using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public class VendedorDataProvider : IVendedorDataProvider
    {
        private readonly IDbConnection _dbConnection;

        public VendedorDataProvider(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Vendedor>> GetVendedores()
        {
            return await _dbConnection.QueryAsync<Vendedor>(
                "API.spVendedores",
                commandType: CommandType.StoredProcedure);
        }
    }
}
