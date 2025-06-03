using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ClubeDaLeitura.ConsoleApp1.Program;

namespace ClubeDaLeitura.ConsoleApp1.ModuloCaixas
{
    partial class Program
    {
        public RepositorioCaixa repositorioCaixa = new RepositorioCaixa();
        public class RepositorioCaixa 
        {
            public Caixa[] caixas = new Caixa[100];
            public int contadorCaixas = 0;
            public void CadastrarCaixa(Caixa caixa)
            {
                caixas[contadorCaixas] = caixa;

                contadorCaixas++;
            }

            public Caixa[] SelecionarCaixas()
            {
                Caixa[] caixas = SelecionarCaixas();

                return caixas;
            }

            public bool EditarCaixa(string caixaSelecionado, Caixa caixaAtualizado)
            {
                Caixa etiquetaSelecionado;
                (bool flowControl, bool value) = SelecionarCaixaPorEtiqueta(caixaSelecionado, out etiquetaSelecionado);
                if (!flowControl)
                {
                    return value;
                }

                etiquetaSelecionado.etiqueta = caixaAtualizado.etiqueta;
                etiquetaSelecionado.cor = caixaAtualizado.cor;
                etiquetaSelecionado.diasEmprestimo = caixaAtualizado.diasEmprestimo;

                return true;
            }

            private (bool flowControl, bool value) SelecionarCaixaPorEtiqueta(string caixaSelecionado, out Caixa etiquetaSelecionado)
            {
                etiquetaSelecionado = null;
                for (int i = 0; i < caixas.Length; i++)
                {
                    Caixa c = caixas[i];

                    if (c == null)
                        continue;

                    if (c.etiqueta == caixaSelecionado)
                        etiquetaSelecionado = c;
                }

                if (etiquetaSelecionado == null)
                    return (flowControl: false, value: false);
                return (flowControl: true, value: default);
            }

            public bool ExcluirCaixa(string caixaSelecionado)
            {
                Caixa etiquetaSelecionado = null;

                for (int i = 0; i < caixas.Length; i++)
                {
                    Caixa c = caixas[i];

                    if (c == null)
                        continue;

                    if (c.etiqueta == caixaSelecionado)
                    {
                        etiquetaSelecionado = c;
                        break;
                    }
                }

                if (etiquetaSelecionado == null)
                    return false;

                for (int i = 0; i < caixas.Length; i++)
                {
                    if (caixas[i] == etiquetaSelecionado)
                    {
                        caixas[i] = null;
                        return true;
                    }
                }
                return false;

            }




        }
    }
}

