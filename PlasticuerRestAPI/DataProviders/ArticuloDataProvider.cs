using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public class ArticuloDataProvider : IArticuloDataProvider
    {
        private readonly IDbConnection _dbConnection;

        public ArticuloDataProvider(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Articulo>> GetArticulos()
        {
            using (_dbConnection)
            {
                string sql = "exec API.spArticulos";

                return await _dbConnection.QueryAsync<Articulo>(
                    sql,
                    null,
                    commandType: CommandType.Text);
            }

        }
    }
}
