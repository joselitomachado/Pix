namespace Pix.Models
{
    public class Layout
    {
        private static List<Cliente> clientes = new();
        private static int opcao = 0;

        private static void Telinha()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();

            Console.WriteLine("\nBanking Digio - TRANSFERÊNCIA VIA PIX\n");
        }

        public static void Menu()
        {
            try
            {
                Telinha();

                Console.WriteLine("DIGITE UMA OPÇÃO ABAIXO: \n");
                Console.WriteLine("[1] - Cadastrar");
                Console.WriteLine("[2] - Transferir");
                Console.WriteLine("[3] - Sair ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Cadastro();
                        break;
                    case 2:
                        Transferir();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Menu();
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Thread.Sleep(2000);
                Menu();
            }
        }

        private static void Cadastro()
        {
            Telinha();

            Console.WriteLine("Digite seu Nome:");
            string nome = Console.ReadLine();
            if (string.IsNullOrEmpty(nome)) throw new Exception("Campo [Nome] é obrigatório");

            Console.WriteLine("Digite seu CPF:");
            string cpf = Console.ReadLine();
            if (string.IsNullOrEmpty(cpf)) throw new Exception("Campo [CPF] é obrigatório");
            if (!Cliente.ValidarCPF(cpf)) throw new Exception("CPF inválido");
            if (CPFCadastrado(cpf)) throw new Exception("CPF já cadastrado");

            Console.WriteLine("Digite a Chave Pix:");
            string chavePix = Console.ReadLine();
            if (string.IsNullOrEmpty(chavePix)) throw new Exception("Campo [Chave Pix] é obrigatório");
            if (!Cliente.ValidarPix(chavePix)) throw new Exception("Chave Pix inválido");
            if (PixCadastrado(chavePix)) throw new Exception("Chave Pix já cadastrado");

            Cliente cliente = new();

            cliente.Nome = nome;
            cliente.CPF = cpf;
            cliente.Pix = chavePix;

            clientes.Add(cliente);

            Telinha();

            Console.WriteLine("Cadastro realizado com sucesso!\n");
            Console.WriteLine("Confira seus dados abaixo:");
            Console.WriteLine($"NOME: {nome} \nCPF: {cpf} \nCHAVE PIX: {chavePix}");

            Voltar();
        }

        private static bool CPFCadastrado(string cpf)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.CPF == cpf)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool PixCadastrado(string chavePix)
        {
            foreach (Cliente cliente in clientes)
            {
                if (cliente.Pix == chavePix)
                {
                    return true;
                }
            }

            return false;
        }

        private static void Transferir()
        {
            Telinha();

            Console.WriteLine("Digite a Chave Pix:");
            string chavePix = Console.ReadLine();
            if (string.IsNullOrEmpty(chavePix)) throw new Exception("Campo [Chave PIX] é obrigatório");

            var pix = clientes.Where(x => x.Pix == chavePix).FirstOrDefault();

            if (pix == null)
            {
                throw new Exception("Chave Pix digitada não foi encontrada, verifique os dados e tente novamente");
            }

            Console.WriteLine("Digite o valor da transferência: ");
            double valorPix = double.Parse(Console.ReadLine());

            if (valorPix > 0)
            {
                Console.WriteLine("\nPIX enviado com sucesso\n");
                Console.WriteLine($"Confira para quem foi: ");
                Console.WriteLine($"NOME: {pix.Nome} \nCPF: {pix.CPF} \nCHAVE PIX: {pix.Pix}");
            }

            Voltar();
        }

        private static void Voltar()
        {
            Console.WriteLine("\nDigite [ 1 ] para voltar\n");
            opcao = int.Parse(Console.ReadLine());

            if(opcao == 1)
            {
                Menu();
            }
        }
    }
}
