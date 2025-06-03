using System.Text.RegularExpressions;

namespace ClubeDaLeitura.ConsoleApp1
{
    partial class Program
    {
        //Apresentação
        public class TelaAmigo
        {
            public RepositorioAmigo repositorioAmigo = new RepositorioAmigo();

            public void ExibirCabecalho()
            {
                Console.Clear();
                Console.WriteLine("Gestão de Amigos");
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

                Amigo amigo = ObterDados();

                if (!ValidarAmigo(amigo, out string mensagemErro))
                {
                    Console.WriteLine(mensagemErro);
                    Console.ReadLine();
                    return;
                }

                repositorioAmigo.CadastrarAmigo(amigo);

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

                Amigo amigoAtualizado = ObterDados();

                if (!ValidarAmigo(amigoAtualizado, out string mensagemErro))
                {
                    Console.WriteLine(mensagemErro);
                    Console.ReadLine();
                    return;
                }

               

                bool conseguiuEditar = repositorioAmigo.EditarAmigo(amigoSelecionado, amigoAtualizado);

                if (!conseguiuEditar)
                {
                    Console.WriteLine("Não foi possivel encontrar o amigo");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine($"\nAmigo \"{amigoAtualizado.nome}\" atualizado com exito!");
                Console.ReadLine();
            }

            public void ExcluirAmigos()
            {
                ExibirCabecalho();

                Console.WriteLine("Exclusão de Amigos");
                Console.WriteLine();

                VisualizarAmigos(false);

                Console.WriteLine("Escolha o Amigo que deseja excluir: ");
                string amigoSelecionado = Console.ReadLine();

                bool conseguiuExcluir = repositorioAmigo.ExcluirAmigo(amigoSelecionado);

                if (!conseguiuExcluir)
                {
                    Console.WriteLine("Não foi possivel encontrar o amigo");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine($"\nAmigo excluído com sucesso!");
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
                if (exibirCabecalho)
                    ExibirCabecalho();

                Console.Clear();

                Console.WriteLine("Visualização de Amigos");
                Console.WriteLine();

                Console.WriteLine(
                    "{0, -10} | {1, -10} | {2, -11}",
                    "Nome", "Responsável", "Telefone");

                bool encontrou = false;
                for (int i = 0; i < repositorioAmigo.amigos.Length; i++)
                {
                    Amigo a = repositorioAmigo.amigos[i];
                    if (a == null)
                        continue;

                    encontrou = true;
                    Console.WriteLine(
                        "{0, -10} | {1, -10} | {2, -11}",
                        a.nome, a.responsavel, a.telefone);
                }

                if (!encontrou)
                    Console.WriteLine("Nenhum amigo cadastrado.");

                Console.ReadLine();
            }

            public bool ValidarAmigo(Amigo amigo, out string mensagemErro)
            {
                mensagemErro = "";

                if (string.IsNullOrWhiteSpace(amigo.nome) || amigo.nome.Length < 3 || amigo.nome.Length > 100)
                {
                    mensagemErro = "Nome deve ter entre 3 e 100 caracteres.";
                    return false;
                }

                if (string.IsNullOrWhiteSpace(amigo.responsavel) || amigo.responsavel.Length < 3 || amigo.responsavel.Length > 100)
                {
                    mensagemErro = "Nome do responsável deve ter entre 3 e 100 caracteres.";
                    return false;
                }

                if (!Regex.IsMatch(amigo.telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$"))
                {
                    mensagemErro = "Telefone deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.";
                    return false;
                }

                
                foreach (var a in repositorioAmigo.amigos)
                {
                    if (a != null && a.nome == amigo.nome && a.telefone == amigo.telefone)
                    {
                        mensagemErro = "Já existe um amigo cadastrado com o mesmo nome e telefone.";
                        return false;
                    }
                }

                return true;
            }
        }
    }
}

