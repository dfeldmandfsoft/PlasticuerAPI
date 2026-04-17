namespace PlasticuerRestAPI.Models
{
    public class Pedido
    {
        public int idCliente { get; set; }
        public int idVendedor { get; set; }
        public List<PedidoItem> articulos { get; set; } = [];
        public string? observaciones { get; set; }
    }

    public class PedidoItem
    {
        public int idArticulo { get; set; }
        public string? descripcion { get; set; }
        public int cantidad { get; set; }
        public string? preciofinal { get; set; }
    }
}
