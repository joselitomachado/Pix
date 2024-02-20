namespace Pix.Models
{
    public class Cliente
    {
        public string Nome { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Pix { get; set; } = string.Empty;

        public double Saldo = 1000;

        public bool TransferenciaPix(Cliente chavePix, double valor)
        {
            if (valor > Saldo)
            {
                return false;
            }

            this.Saldo -= valor;
            chavePix.Saldo += valor;
            return true;
        }
    }
}