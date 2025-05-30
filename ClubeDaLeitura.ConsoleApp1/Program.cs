

using static ClubeDaLeitura.ConsoleApp1.Program.TelaAmigo;

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
                        telaAmigo.CadastrarAmigos();
                        break;

                    case '2':
                        telaAmigo.EditarAmigos();
                        break;

                    case '4':
                        telaAmigo.VisualizarAmigos(true);
                        break;
                }
            }
        }

        //Apresentação
        public class TelaAmigo
        {
            public RepositorioAmigo repositorioAmigo = new RepositorioAmigo();

            public void ExibirCabecalho()
            {
                Console.Clear();
                Console.WriteLine("Clube do Livro");
                Console.WriteLine();
            }

            public char ApresentarMenu()
            {
                ExibirCabecalho();

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

            public void CadastrarAmigos()
            {
                ExibirCabecalho();

                Console.WriteLine("Cadastro de Amigos");

                Console.Clear();
                Amigo amigo = ObterDados();

                repositorioAmigo.amigos[0] = amigo;

                Console.Clear();
                Console.WriteLine($"\nAmigo \"{amigo.nome}\" cadastrado com exito!");
                Console.ReadLine();
            }

            

            public void EditarAmigos()
            {
                ExibirCabecalho();

                Console.WriteLine("Edição de Amigos");
                Console.WriteLine();

                VisualizarAmigos(false);

                Console.WriteLine("Escolha o Amigo que deseja editar: ");
                string amigoSelecionado = Console.ReadLine();

                Amigo nomeSelecionado = null;

                Amigo[] amigos = repositorioAmigo.amigos;

                for (int i = 0; i < repositorioAmigo.amigos.Length; i++)
                {
                    Amigo a = amigos[i];

                    if (a == null)
                        continue;

                    if (a.nome == amigoSelecionado)
                        nomeSelecionado = a;
                }

                if (nomeSelecionado == null) 
                    return;

                Amigo amigoAtualizado = ObterDados();

                nomeSelecionado.nome = amigoAtualizado.nome;
                nomeSelecionado.responsavel = amigoAtualizado.responsavel;
                nomeSelecionado.telefone = amigoAtualizado.telefone;

                Console.WriteLine($"\nAmigo \"{nomeSelecionado.nome}\" atualizado com exito!");
                Console.ReadLine();
            }

            public Amigo ObterDados()
            {
                Console.WriteLine("Digite o nome do amigo: ");
                string nomeAmigo = Console.ReadLine();

                
                Console.WriteLine("Digite o responsável: ");
                string responsavelAmigo = Console.ReadLine();

                
                Console.WriteLine("Digite o telefone: ");
                string telefoneAmigo = Console.ReadLine();


                Amigo amigo = new Amigo();
                amigo.nome = nomeAmigo;
                amigo.responsavel = responsavelAmigo;
                amigo.telefone = telefoneAmigo;
                return amigo;
            }

            public void VisualizarAmigos(bool exibirCabecalho)
                
            {
                if (exibirCabecalho == true)
                    ExibirCabecalho();

                Console.Clear();

                Console.WriteLine("Visualização de Amigos");
                Console.WriteLine();

                Console.WriteLine(
                    "{0, -10} | {1, -10} | {2, -11}",
                    "Nome", "Responsável", "Telefone");

                Amigo[] amigos = repositorioAmigo.amigos;

                for (int i = 0; i < repositorioAmigo.amigos.Length; i++)
                {
                    Amigo a = amigos[i];

                    if (a == null)
                        continue;

                    Console.WriteLine(
                    "{0, -10} | {1, -10} | {2, -11}",
                    a.nome, a.responsavel, a.telefone);

                    Console.ReadLine();
                }
            }



            //Dados
            public class RepositorioAmigo
            {
                public Amigo[] amigos = new Amigo[100];


            }

            //Negócio
            public class Amigo
            {
                public string nome;
                public string responsavel;
                public string telefone;
            }
        }
    }
}
