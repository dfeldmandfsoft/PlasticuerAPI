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
            return await _dbConnection.QueryAsync<Localidad>(
                "API.spLocalidades",
                new { idProvincia },
                commandType: CommandType.StoredProcedure);
        }
    }
}
