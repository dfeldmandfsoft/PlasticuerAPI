using Dapper;
using System.Data;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public class LocalidadDataProvider : ILocalidadDataProvider
    {
        private readonly IDbConnection _dbConnection;

        public LocalidadDataProvider(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Localidad>> GetLocalidades(int idProvincia)
        {
            using (_dbConnection)
            {
                return await _dbConnection.QueryAsync<Localidad>(
                    "exec API.spLocalidades @idProvincia",
                    new { idProvincia },
                    commandType: CommandType.Text);
            }
        }
    }
}
