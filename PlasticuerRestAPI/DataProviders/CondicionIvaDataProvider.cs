using Dapper;
using System.Data;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public class CondicionIvaDataProvider : ICondicionIvaDataProvider
    {
        private readonly IDbConnection _dbConnection;

        public CondicionIvaDataProvider(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<CondicionIva>> GetCondicionesIva()
        {
            return await _dbConnection.QueryAsync<CondicionIva>(
                "API.spCondicionesIva",
                commandType: CommandType.StoredProcedure);
        }

        public async Task<CondicionIva?> GetCondicionIva(int idCondicionIva)
        {
            return await _dbConnection.QueryFirstOrDefaultAsync<CondicionIva>(
                "API.spCondicionIva",
                new { idCondicionIva },
                commandType: CommandType.StoredProcedure);
        }
    }
}
