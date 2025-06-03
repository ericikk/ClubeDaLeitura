using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static ClubeDaLeitura.ConsoleApp1.ModuloCaixas.Program;
using static ClubeDaLeitura.ConsoleApp1.Program;

namespace ClubeDaLeitura.ConsoleApp1.ModuloCaixas
{
    public class TelaCaixas
    {
        private RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
        public void ExibirCabecalho()
        {
            Console.Clear();
            Console.WriteLine("Gestão de Caixas");
            Console.WriteLine();
        }

        public char ApresentarMenu()
        {
            ExibirCabecalho();

            Console.WriteLine("1 - Cadastrar Caixas");
            Console.WriteLine("2 - Editar Caixas");
            Console.WriteLine("3 - Excluir Caixas");
            Console.WriteLine("4 - Visualizar Caixas");
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma Opção: ");
            char opcaoEscolhida = Console.ReadLine().ToUpper()[0];

            return opcaoEscolhida;
        }

        public void CadastrarCaixas()
        {
            ExibirCabecalho();

            Console.WriteLine("Cadastro de Caixas");

            Caixa caixa = obterDados();

            if (!ValidarCaixa(caixa, out string mensagemErro))
            {
                Console.WriteLine(mensagemErro);
                Console.ReadLine();
                return;
            }

            repositorioCaixa.CadastrarCaixa(caixa);

            Console.Clear();
            Console.WriteLine($"\nCaixa \"{caixa.etiqueta}\" cadastrada com exito!");
            Console.ReadLine();
        }

        public void EditarCaixas()
        {
            ExibirCabecalho();

            Console.WriteLine("Edição de Caixas");
            Console.WriteLine();

            VisualizarCaixas(false);

            Console.WriteLine("Escolha a Etiqueta da Caixa que deseja editar: ");
            string etiquetaSelecionada = Console.ReadLine();

            Caixa caixaAtualizada = obterDados();

            bool conseguiuEditar = repositorioCaixa.EditarCaixa(etiquetaSelecionada, caixaAtualizada);

            if (!conseguiuEditar)
            {
                Console.WriteLine("Não foi possível encontrar a caixa");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\nCaixa \"{caixaAtualizada.etiqueta}\" atualizada com êxito!");
            Console.ReadLine();
        }

        public void ExcluirCaixas()
        {
            ExibirCabecalho();

            Console.WriteLine("Exclusão de Caixas");
            Console.WriteLine();

            VisualizarCaixas(false);

            Console.WriteLine("Escolha a Etiqueta da Caixa que deseja excluir: ");
            string etiquetaSelecionada = Console.ReadLine();

            bool conseguiuExcluir = repositorioCaixa.ExcluirCaixa(etiquetaSelecionada);

            if (!conseguiuExcluir)
            {
                Console.WriteLine("Não foi possível encontrar a caixa");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"\nCaixa excluída com sucesso!");
            Console.ReadLine();
        }

        public void VisualizarCaixas(bool exibirCabecalho)
        {
            if (exibirCabecalho)
                ExibirCabecalho();

            Console.Clear();

            Console.WriteLine("Visualização de Caixas");
            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -10} | {2, -11}",
                "Etiqueta", "Cor", "D. Empréstimos");

            bool encontrou = false;
            for (int i = 0; i < repositorioCaixa.caixas.Length; i++)
            {
                Caixa c = repositorioCaixa.caixas[i];
                if (c == null)
                    continue;

                encontrou = true;
                Console.WriteLine(
                    "{0, -10} | {1, -10} | {2, -11}",
                    c.etiqueta, c.cor, c.diasEmprestimo);
            }

            if (!encontrou)
                Console.WriteLine("Nenhuma caixa cadastrada.");

            Console.ReadLine();
        }

        public Caixa obterDados()
        {
            Console.WriteLine("Digite a etiqueta da caixa: ");
            string etiqueta = Console.ReadLine();

            string[] paletaCores = { "Vermelho", "Verde", "Azul", "Amarelo", "Preto", "Branco", "Roxo", "Rosa", "Laranja" };
            Console.WriteLine("Selecione a cor da caixa: ");
            for (int i = 0; i < paletaCores.Length; i++)
                Console.WriteLine($"{i + 1} - {paletaCores[i]}");

            int corIndex = 0;
            while (true)
            {
                Console.Write("Digite o número da cor desejada: ");
                string corInput = Console.ReadLine();
                if (int.TryParse(corInput, out corIndex) && corIndex >= 1 && corIndex <= paletaCores.Length)
                    break;
                Console.WriteLine("Opção inválida. Tente novamente.");
            }
            string cor = paletaCores[corIndex - 1];


            Console.WriteLine("Dias de empréstimo (pressione Enter para padrão 7): ");
            string diasEmprestimo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(diasEmprestimo))
                diasEmprestimo = "7";

            Caixa caixa = new Caixa();
            caixa.etiqueta = etiqueta;
            caixa.cor = cor;
            caixa.diasEmprestimo = diasEmprestimo;
            return caixa;
        }

        public bool ValidarCaixa(Caixa caixa, out string mensagemErro)
        {
            mensagemErro = "";

            if (string.IsNullOrWhiteSpace(caixa.etiqueta) || caixa.etiqueta.Length < 1 || caixa.etiqueta.Length > 50)
            {
                mensagemErro = "Etiqueta deve ter entre 1 e 50 caracteres.";
                return false;
            }

            if (caixa.etiqueta.Contains(" "))
            {
                mensagemErro = "A etiqueta não pode conter espaços.";
                return false;
            }

            // Verifica duplicidade de etiqueta
            foreach (var c in repositorioCaixa.caixas)
            {
                if (c != null && c.etiqueta == caixa.etiqueta)
                {
                    mensagemErro = "Já existe uma caixa com essa etiqueta.";
                    return false;
                }
            }

            return true;
        }
    }
}
