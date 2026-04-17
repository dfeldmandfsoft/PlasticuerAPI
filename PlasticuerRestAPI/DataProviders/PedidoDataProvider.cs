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

            using (_dbConnection)
            {
                string sql = "exec API.spGuardarPedido @stringpedido";

                await _dbConnection.ExecuteAsync(
                    sql,
                    new { stringpedido = mipedido },
                    commandType: CommandType.Text);
            }
        }
    }
}
