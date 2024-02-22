namespace Pix.Models
{
    public class Cliente
    {
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Pix { get; set; } = string.Empty;

        public static bool ValidarCPF(string cpf)
        {
            return cpf.Length == 11;
        }

        public static bool ValidarPix(string chavePix)
        {
            return chavePix.Length >= 6;
        }
    }
}