namespace Pix.Models
{
    public class Layout
    {
        private static int opcao = 0;
        public static void Menu()
        {
            Console.WriteLine("\nDIGITE UMA OPÇÃO ABAIXO: \n");
            Console.WriteLine("1 - Entrar com CPF e Senha");
            Console.WriteLine("2 - Realizar Cadastro");
            Console.WriteLine("3 - Sair ");

            opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    Login();
                    break;
                case 2:
                    Cadastro();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
                default:
                    Menu();
                    break;
            }
        }

        private static void Login()
        {
            Console.Clear();

            Console.WriteLine("Digite seu CPF:");
            string cpf = Console.ReadLine();

            Console.WriteLine("Digite sua Senha:");
            string senha = Console.ReadLine();
        }

        private static void Cadastro()
        {
            Console.Clear();

            Console.WriteLine("Digite seu Nome:");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite seu CPF:");
            string cpf = Console.ReadLine();

            Console.WriteLine("Digite sua senha:");
            string senha = Console.ReadLine();
        }

        private static void Logado()
        {
            Console.Clear();

            Console.WriteLine("\nDIGITE UMA OPÇÃO ABAIXO: \n");
            Console.WriteLine("1 - Transferência via PIX");
            Console.WriteLine("2 - Sair");

            opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    Transferencia();
                    break;
                case 2:
                    Menu();
                    break;
                default:
                    Logado();
                    break;
            }

        }

        private static void Transferencia()
        {
            Console.Clear();

            Console.WriteLine("Digite a chave PIX: ");
            string pix = Console.ReadLine();

            Console.WriteLine("Digite o valor: ");
            double valorPix = double.Parse(Console.ReadLine());

        }
    }
}
