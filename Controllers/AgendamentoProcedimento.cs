using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class AgendamentoProcedimentoController
    {
        public static AgendamentoProcedimento InserirAgendamentoProcedimento(
            int AgendamentoId,
            int ProcedimentoId
        )
        {
            PacienteController.GetAgendamento(AgendamentoId);
            DentistaController.GetProcedimento(ProcedimentoId);
            return new AgendamentoProcedimento();
        }

        public static AgendamentoProcedimento ExcluirAgendamentoProcedimento(
            int Id
        )
        {
            AgendamentoProcedimento agendamentoProcedimento = GetAgendamentoProcedimento(Id);
            AgendamentoProcedimento.RemoverAgendamentoProcedimento(agendamentoProcedimento);
            return agendamentoProcedimento;
        }
        public static List<AgendamentoProcedimento> VisualizarAgendamentos()
        {
            return AgendamentoProcedimento.GetAgendamentoProcedimentos();
        }
        public static AgendamentoProcedimento GetAgendamentoProcedimento(
            int Id
        )
        {
            AgendamentoProcedimento agendamentoProcedimento = (
                from AgendamentoProcedimento in AgendamentoProcedimento.GetAgendamentoProcedimentos()
                    where AgendamentoProcedimento.Id == Id
                    select AgendamentoProcedimento
            ).First();

            if (agendamentoProcedimento == null)
            {
                throw new Exception("Atendimento não encontrado.");
            }

            return agendamentoProcedimento;
        }
    }
}
