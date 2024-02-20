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

            Console.WriteLine("\nTRANSFERÊNCIA VIA PIX - Banking Digio\n");
        }

        public static void Menu()
        {
            try
            {
                Telinha();

                Console.WriteLine("DIGITE UMA OPÇÃO ABAIXO: \n");
                Console.WriteLine("1 - Realizar Cadastro");
                Console.WriteLine("2 - Entrar com CPF e Senha");
                Console.WriteLine("3 - Sair ");

                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Cadastro();
                        break;
                    case 2:
                        Login();
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

            Console.WriteLine("Digite sua Chave PIX:");
            string chavePix = Console.ReadLine();
            if (string.IsNullOrEmpty(chavePix)) throw new Exception("Campo [Chave Pix] é obrigatório");

            Console.WriteLine("Digite sua senha:");
            string senha = Console.ReadLine();
            if (string.IsNullOrEmpty(senha)) throw new Exception("Campo [Senha] é obrigatório");

            Cliente cliente = new();

            cliente.Nome = nome;
            cliente.CPF = cpf;
            cliente.Pix = chavePix;
            cliente.Senha = senha;

            clientes.Add(cliente);

            Console.WriteLine("\nCliente cadastrado com sucesso!\n");

            Thread.Sleep(2000);
            Logado(cliente);
        }

        private static void Login()
        {
            Telinha();

            Console.WriteLine("Digite seu CPF:");
            string cpf = Console.ReadLine();
            if (string.IsNullOrEmpty(cpf)) throw new Exception("Campo [CPF] é obrigatório");

            Console.WriteLine("Digite sua Senha:");
            string senha = Console.ReadLine();
            if (string.IsNullOrEmpty(senha)) throw new Exception("Campo [Senha] é obrigatório");

            var cliente = clientes.FirstOrDefault(x => x.CPF == cpf && x.Senha == senha);

            if (cliente != null)
            {
                Logado(cliente);
            }
            else
            {
                Console.WriteLine("CPF ou Senha invalida!");

                Thread.Sleep(2000);
                Menu();
            }
        }

        private static void Perfil(Cliente cliente)
        {
            Console.WriteLine($"NOME: {cliente.Nome} | CPF: {cliente.CPF} | CHAVE PIX: {cliente.Pix} | SALDO: R${cliente.Saldo}\n");
        }

        private static void Logado(Cliente cliente)
        {
            try
            {
                Telinha();
                Perfil(cliente);

                Console.WriteLine("DIGITE UMA OPÇÃO ABAIXO: \n");
                Console.WriteLine("1 - Transferência via PIX");
                Console.WriteLine("2 - Sair");

                opcao = int.Parse(Console.ReadLine());
                switch (opcao)
                {
                    case 1:
                        Transferencia(cliente);
                        break;
                    case 2:
                        Menu();
                        break;
                    default:
                        Logado(cliente);
                        break;
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Thread.Sleep(2000);
                Logado(cliente);
            }
        }

        private static void Transferencia(Cliente cliente)
        {
            Telinha();
            Perfil(cliente);

            Console.WriteLine("Digite a chave PIX: ");
            string chavePix = Console.ReadLine();
            if (string.IsNullOrEmpty(chavePix)) throw new Exception("Campo [Chave PIX] é obrigatório");

            var pix = clientes.Where(x => x.Pix == chavePix).FirstOrDefault();

            if (pix == null)
            {
                throw new Exception("Pix digitado não foi encontrada.");
            }

            if (chavePix == cliente.Pix)
            {
                throw new Exception("Não conseguimos realizar a transferência para este pix");
            }

            Console.WriteLine("Digite o valor: ");
            double valorPix = double.Parse(Console.ReadLine());

            if (valorPix <= cliente.Saldo && valorPix > 0)
            {
                cliente.TransferenciaPix(pix, valorPix);
                Console.WriteLine("Pix realizando com sucesso!");
            }
            else
            {
                Console.WriteLine("Saldo insuficiente!");
            }

            Thread.Sleep(2000);
            Logado(cliente);
        }
    }
}
