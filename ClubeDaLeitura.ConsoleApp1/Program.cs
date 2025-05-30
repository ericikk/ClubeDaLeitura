using System.Reflection.Metadata;

namespace ClubeDaLeitura.ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            TelaAmigo telaAmigo = new TelaAmigo();

            while (true)
            {
                char opcaoEscolhida = telaAmigo.ApresentarMenu();

                if (opcaoEscolhida == 'S')
                    break;

                switch (opcaoEscolhida)
                {
                    case '1':
                        telaAmigo.CadastrarAmigo();
                        break;

                }
            }
        }

        public class TelaAmigo
        {
            public char ApresentarMenu()
            {
                Console.Clear();
                Console.WriteLine("Clube do Livro");

                Console.WriteLine();

                Console.WriteLine("1 - Cadastrar Amigos");
                Console.WriteLine("2 - Editar Amigos");
                Console.WriteLine("3 - Excluir Amigos");
                Console.WriteLine("4 - Visualizar Amigos");
                Console.WriteLine("5 - Visualizar Empréstimos de Amigos");
                Console.WriteLine("S - Sair");

                Console.WriteLine();

                Console.Write("Escolha uma Opção: ");
                char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

                return opcaoEscolhida;
            }

            public void CadastrarAmigo()
            {
                Console.Clear();
                Console.WriteLine("Clube do Livro");
                Console.WriteLine();


                Console.WriteLine("Cadastro de Amigos");

                Console.Clear();
                Console.WriteLine("Digite o nome do amigo: ");
                string nomeAmigo = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Digite o responsável: ");
                string responsavelAmigo = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Digite o telefone: ");
                string telefoneAmigo = Console.ReadLine();


                Amigo amigo = new Amigo();
                amigo.nome = nomeAmigo;
                amigo.responsavel = responsavelAmigo;
                amigo.telefone = telefoneAmigo;

                Console.Clear();
                Console.WriteLine($"\nAmigo \"{amigo.nome}\" cadastrado com exito!");
                Console.ReadLine();
            }
        }

        public class Amigo
        {
            public string nome;
            public string responsavel;
            public string telefone;
        }
    }
}
