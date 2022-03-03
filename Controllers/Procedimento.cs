using System;
using System.Collections.Generic;
using System.Linq;
using Models;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class ProcedimentoController 
    {
        public static Procedimento InserirProcedimento(
            string Descricao,
            double Preco
        )
        {
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descricao inválido");
            }
            
            if (Preco <= 0)
            {
                throw new Exception("Preco inválido");
            }
            return new Procedimento(Descricao, Preco);
        }

        public static Procedimento AlterarProcedimento(
            int Id,
            string Descricao,
            double Preco
        )
        {
            Procedimento procedimento = GetProcedimento(Id);

            if (!String.IsNullOrEmpty(Descricao))
            {
                procedimento.Descricao = Descricao;
            }

            if (Preco > 0)
            {
                procedimento.Preco = Preco;
            }
            return procedimento;
        }

        public static Procedimento ExcluirProcedimento(
            int Id
        )
        {
            Procedimento procedimento = GetProcedimento(Id);
            Procedimento.RemoverProcedimento(procedimento);
            return procedimento;
        }

        public static List<Procedimento> VisualizarProcedimento()
        {
            return Procedimento.GetProcedimentos();
        }

        public static Procedimento GetProcedimento(int Id)
        {
            Procedimento procedimento = (
                from Procedimento in Procedimento.GetProcedimentos()
                    where Procedimento.Id == Id
                    select Procedimento
            ).First();

            if (procedimento == null)
            {
                throw new Exception("Procedimento não encontrado");
            }
            return procedimento;
        }
    }
}
