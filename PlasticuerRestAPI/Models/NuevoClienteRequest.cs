using System.ComponentModel.DataAnnotations;

namespace PlasticuerRestAPI.Models
{
    public class NuevoClienteRequest
    {
        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [MaxLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [MaxLength(50, ErrorMessage = "La dirección no puede superar los 50 caracteres.")]
        public string? Direccion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La provincia es obligatoria.")]
        public int IdProvincia { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La localidad es obligatoria.")]
        public int IdLocalidad { get; set; }

        [MaxLength(8, ErrorMessage = "El CPA no puede superar los 8 caracteres.")]
        public string? CPA { get; set; }

        [MaxLength(50, ErrorMessage = "El teléfono no puede superar los 50 caracteres.")]
        public string? Telefono { get; set; }

        [MaxLength(200, ErrorMessage = "El mail no puede superar los 200 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato del mail no es válido.")]
        public string? Mail { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La condición de IVA es obligatoria.")]
        public int IdCondicionIva { get; set; }

        [Required(ErrorMessage = "El CUIT/DNI es obligatorio.")]
        [MaxLength(11, ErrorMessage = "El CUIT/DNI no puede superar los 11 caracteres.")]
        public string? CuitDni { get; set; }
    }
}
