﻿

using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp1.ModuloEmprestimo
{
    public class RepositorioEmprestimo : RepositorioBase
    {
        public Emprestimo[] SelecionarEmprestimosAtivos()
        {
            int contadorEmprestimosAtivos = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                Emprestimo emprestimoAtual = (Emprestimo)registros[i];

                if (emprestimoAtual == null)
                    continue;

                if (emprestimoAtual.Status == "Disponível" || emprestimoAtual.Status == "Atrasado")
                    contadorEmprestimosAtivos++;
            }

            Emprestimo[] emprestimosAtivos = new Emprestimo[contadorEmprestimosAtivos];

            int contadorAuxiliar = 0;

            for (int i = 0; i < registros.Length; i++)
            {
                Emprestimo emprestimoAtual = (Emprestimo)registros[i];

                if (emprestimoAtual == null)
                    continue;

                if (emprestimoAtual.Status == "Disponível" || emprestimoAtual.Status == "Atrasado")
                {
                    emprestimosAtivos[contadorAuxiliar] = (Emprestimo)registros[i];
                }
            }

            return emprestimosAtivos;
        }
    }
}
