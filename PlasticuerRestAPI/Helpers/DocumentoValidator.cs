namespace PlasticuerRestAPI.Helpers
{
    public static class DocumentoValidator
    {
        public static bool ValidarDni(string dni)
        {
            var digitos = dni.Trim().Replace("-", "").Replace(".", "");
            return digitos.Length >= 6 && digitos.All(char.IsDigit);
        }

        public static bool ValidarCuit(string cuit)
        {
            var digitos = cuit.Trim().Replace("-", "").Replace(".", "");

            if (digitos.Length != 11 || !digitos.All(char.IsDigit))
                return false;

            int[] pesos = [5, 4, 3, 2, 7, 6, 5, 4, 3, 2];
            int suma = 0;
            for (int i = 0; i < 10; i++)
                suma += (digitos[i] - '0') * pesos[i];

            int resto = suma % 11;
            int verificador = 11 - resto;

            if (verificador == 11) verificador = 0;
            if (verificador == 10) return false;

            return verificador == (digitos[10] - '0');
        }
    }
}
