using System;
using System.Collections.Generic;

namespace Models
{
    public class AgendamentoProcedimento
    {
        public static int ID = 0;
        private static List<AgendamentoProcedimento> AgendamentoProcedimentos = new List<AgendamentoProcedimento>();
        public int Id { set; get; }
        public int IdAgendamento { set; get; }
        public Agendamento Agendamento { set; get; }
        public int IdProcedimento { set; get; }
        public Procedimento Procedimento { set; get; }

        public AgendamentoProcedimento(
            int IdAgendamento,
            int IdProcedimento
        ) : this(++ID, IdAgendamento, IdProcedimento)
        {}

        private AgendamentoProcedimento(
            int Id,
            int IdAgendamento,
            int IdProcedimento
        )
        {
            this.Id = Id;
            this.IdAgendamento = IdAgendamento;
            this.Agendamento = Agendamento.GetAgendamentos().Find(Agendamento => Agendamento.Id == IdAgendamento);
            this.IdProcedimento = IdProcedimento;
            this.Procedimento = Procedimento.GetProcedimentos().Find(Procedimento => Procedimento.Id == IdProcedimento);
            
            AgendamentoProcedimentos.Add(this);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!AgendamentoProcedimento.ReferenceEquals(obj, this))
            {
                return false;
            }
            AgendamentoProcedimento it = (AgendamentoProcedimento) obj;
            return it.Id == this.Id;
        }
        public static List<AgendamentoProcedimento> GetAgendamentoProcedimentos()
        {
            return AgendamentoProcedimentos;
        }

        public static void RemoverAgendamentoProcedimento(
            AgendamentoProcedimento agendamentoProcedimento
        )
        {
            AgendamentoProcedimentos.Remove(agendamentoProcedimento);
        }

    }
}
