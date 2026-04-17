using System.Text.Json.Serialization;

namespace PlasticuerRestAPI.Models
{
    public class Provincia
    {
        [JsonPropertyName("id")]
        public int IdProvincia { get; set; }

        [JsonPropertyName("descripcion")]
        public string? Nombre { get; set; }
    }
}
