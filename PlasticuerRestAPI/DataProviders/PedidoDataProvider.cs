using Dapper;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using PlasticuerRestAPI.Models;

namespace PlasticuerRestAPI.DataProviders
{
    public class PedidoDataProvider : IPedidoDataProvider
    {
        private readonly IDbConnection _dbConnection;

        public PedidoDataProvider(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task PostPedido(Pedido pedido)
        {
            string mipedido = JsonSerializer.Serialize(pedido);

            await _dbConnection.ExecuteAsync(
                "API.spGuardarPedido",
                new { stringpedido = mipedido },
                commandType: CommandType.StoredProcedure);
        }
    }
}
