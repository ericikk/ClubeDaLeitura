
using static ClubeDaLeitura.ConsoleApp1.Program;

namespace ClubeDaLeitura.ConsoleApp1
{
    partial class Program
    {
        //Dados
        public class RepositorioAmigo
        {
            public Amigo[] amigos = new Amigo[100];
            public int contadorAmigos = 0;
            public void CadastrarAmigo(Amigo amigo)
            {
                amigos[contadorAmigos] = amigo;

                contadorAmigos++;
            }

            public Amigo[] SelecionarAmigos()
            {
                Amigo[] amigos = SelecionarAmigos();

                return amigos;
            }

            public bool EditarAmigo(string amigoSelecionado, Amigo amigoAtualizado)
            {
                Amigo nomeSelecionado;
                (bool flowControl, bool value) = SelecionarAmigoPorNome(amigoSelecionado, out nomeSelecionado);
                if (!flowControl)
                {
                    return value;
                }

                nomeSelecionado.nome = amigoAtualizado.nome;
                nomeSelecionado.responsavel = amigoAtualizado.responsavel;
                nomeSelecionado.telefone = amigoAtualizado.telefone;

                return true;
            }

            private (bool flowControl, bool value) SelecionarAmigoPorNome(string amigoSelecionado, out Amigo nomeSelecionado)
            {
                nomeSelecionado = null;
                for (int i = 0; i < amigos.Length; i++)
                {
                    Amigo a = amigos[i];

                    if (a == null)
                        continue;

                    if (a.nome == amigoSelecionado)
                        nomeSelecionado = a;
                }

                if (nomeSelecionado == null)
                    return (flowControl: false, value: false);
                return (flowControl: true, value: default);
            }

            public bool ExcluirAmigo(string amigoSelecionado)
            {
                Amigo nomeSelecionado = null;

                for (int i = 0; i < amigos.Length; i++)
                {
                    Amigo a = amigos[i];

                    if (a == null)
                        continue;

                    if (a.nome == amigoSelecionado)
                    {
                        nomeSelecionado = a;
                        break;
                    }
                }

                if (nomeSelecionado == null)
                    return false;

                for (int i = 0; i < amigos.Length; i++)
                {
                    if (amigos[i] == nomeSelecionado)
                    {
                        amigos[i] = null;
                        return true;
                    }
                }
                return false;

            }

  


        }
        }
    }

