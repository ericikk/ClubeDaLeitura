using ClubeDaLeitura.ConsoleApp1.ModuloCaixas;
using static ClubeDaLeitura.ConsoleApp1.Program.TelaAmigo;

namespace ClubeDaLeitura.ConsoleApp1
{
    partial class Program
    {
        static void Main(string[] args)
        {
            TelaAmigo telaAmigo = new TelaAmigo();
            TelaCaixas telaCaixas = new TelaCaixas();

            while (true)
            {
                char telaEscolhida = ApresentarMenuPrincipal();

                if (telaEscolhida == '1')
                {
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
                            case '3':
                                telaAmigo.ExcluirAmigos();
                                break;
                            case '4':
                                telaAmigo.VisualizarAmigos(true);
                                break;
                        }
                    }
                }
                else if (telaEscolhida == '2')
                {
                    while (true)
                    {
                        char opcaoEscolhida = telaCaixas.ApresentarMenu();

                        if (opcaoEscolhida == 'S')
                            break;

                        switch (opcaoEscolhida)
                        {
                            case '1':
                                telaCaixas.CadastrarCaixas();
                                break;
                            case '2':
                                telaCaixas.EditarCaixas();
                                break;
                            case '3':
                                telaCaixas.ExcluirCaixas();
                                break;
                            case '4':
                                telaCaixas.VisualizarCaixas(true);
                                break;
                        }
                    }
                }
                else if (telaEscolhida == 'S' || telaEscolhida == 's')
                {
                    break;
                }
            }
        }

        public static char ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("-------------------------------");
            Console.WriteLine("        Clube da Leitura        ");
            Console.WriteLine("-------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Gestão de Amigos");
            Console.WriteLine("2 - Gestão de Caixas");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha a opção desejada: ");
            char opcaoEscolhida = Console.ReadLine()[0];

            return opcaoEscolhida;
        }
    }
}
