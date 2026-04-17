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
            using (_dbConnection)
            {
                return await _dbConnection.QueryAsync<CondicionIva>(
                    "exec API.spCondicionesIva",
                    commandType: CommandType.Text);
            }
        }

        public async Task<CondicionIva?> GetCondicionIva(int idCondicionIva)
        {
            using (_dbConnection)
            {
                return await _dbConnection.QueryFirstOrDefaultAsync<CondicionIva>(
                    "exec API.spCondicionIva @idCondicionIva",
                    new { idCondicionIva },
                    commandType: CommandType.Text);
            }
        }
    }
}
