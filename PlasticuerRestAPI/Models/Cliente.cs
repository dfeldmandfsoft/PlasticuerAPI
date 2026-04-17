namespace PlasticuerRestAPI.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string? Nombre { get; set; }
        public string? Direccion { get; set; }
        public string? Localidad { get; set; }
        public string? Provincia { get; set; }
        public string? TipoIVA { get; set; }
        public string? CUIT { get; set; }
    }
}
