

using static ClubeDaLeitura.ConsoleApp1.Program.TelaAmigo;

namespace ClubeDaLeitura.ConsoleApp1
{
    partial class Program
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

                    case '3':
                        telaAmigo.ExcluirAmigos();
                        break;

                    case '4':
                        telaAmigo.VisualizarAmigos(true);
                        break;
                }
            }
        }
        }
    }

