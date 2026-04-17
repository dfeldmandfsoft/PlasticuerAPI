using System.Text.Json.Serialization;

namespace PlasticuerRestAPI.Models
{
    public class Localidad
    {
        [JsonPropertyName("id")]
        public int IdLocalidad { get; set; }

        [JsonPropertyName("descripcion")]
        public string? Nombre { get; set; }
    }
}
