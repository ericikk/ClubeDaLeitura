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

            //if (!ValidarCaixa(caixa, out string mensagemErro))
            //{
            //    Console.WriteLine(mensagemErro);
            //    Console.ReadLine();
            //    return;
            //}

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

            Console.WriteLine("Selecione a cor da caixa: ");
            string cor = Console.ReadLine();

            Console.WriteLine("Dias de empréstimo: ");
            string diasEmprestimo = Console.ReadLine();

            Caixa caixa = new Caixa();
            caixa.etiqueta = etiqueta;
            caixa.cor = cor;
            caixa.diasEmprestimo = diasEmprestimo;
            return caixa;
        }

        //public bool ValidarCaixas(Caixa caixa, out string mensagemErro)
        //{
        //    mensagemErro = "";

        //    if (string.IsNullOrWhiteSpace(amigo.nome) || amigo.nome.Length < 3 || amigo.nome.Length > 100)
        //    {
        //        mensagemErro = "Nome deve ter entre 3 e 100 caracteres.";
        //        return false;
        //    }

        //    if (string.IsNullOrWhiteSpace(amigo.responsavel) || amigo.responsavel.Length < 3 || amigo.responsavel.Length > 100)
        //    {
        //        mensagemErro = "Nome do responsável deve ter entre 3 e 100 caracteres.";
        //        return false;
        //    }

        //    if (!Regex.IsMatch(amigo.telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$"))
        //    {
        //        mensagemErro = "Telefone deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.";
        //        return false;
        //    }

        //    return true;
        //}

        
    }
}
