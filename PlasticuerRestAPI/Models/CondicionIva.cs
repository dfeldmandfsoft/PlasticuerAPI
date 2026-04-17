using System.Text.Json.Serialization;

namespace PlasticuerRestAPI.Models
{
    public class CondicionIva
    {
        [JsonPropertyName("id")]
        public int IdCondicionIva { get; set; }

        [JsonPropertyName("descripcion")]
        public string? Nombre { get; set; }

        [JsonPropertyName("requiereCuit")]
        public bool RequiereCuit { get; set; }
    }
}
