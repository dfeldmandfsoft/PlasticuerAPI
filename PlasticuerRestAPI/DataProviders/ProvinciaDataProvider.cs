using Dapper;
using System.Data;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public class ProvinciaDataProvider : IProvinciaDataProvider
    {
        private readonly IDbConnection _dbConnection;

        public ProvinciaDataProvider(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Provincia>> GetProvincias()
        {
            return await _dbConnection.QueryAsync<Provincia>(
                "API.spProvincias",
                commandType: CommandType.StoredProcedure);
        }
    }
}
