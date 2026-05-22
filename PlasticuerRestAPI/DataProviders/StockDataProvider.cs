using Dapper;
using System.Data;
using System.Threading.Tasks;

namespace PlasticuerRestAPI.DataProviders
{
    public class StockDataProvider : IStockDataProvider
    {
        private readonly IDbConnection _dbConnection;

        public StockDataProvider(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> GetStock(int idArticulo)
        {
            return await _dbConnection.ExecuteScalarAsync<int>(
                "API.spStock",
                new { idArticulo },
                commandType: CommandType.StoredProcedure);
        }
    }
}
