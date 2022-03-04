using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Repository;


namespace Models
{
    public class AgendamentoProcedimento
    {
        public int Id { set; get; }
        [Required]
        public int AgendamentoId { set; get; }
        [Required]
        public Agendamento Agendamento { set; get; }
        [Required]
        public int ProcedimentoId { set; get; }
        [Required]
        public Procedimento Procedimento { set; get; }

        public AgendamentoProcedimento()
        {}

        private AgendamentoProcedimento(
            int Id,
            int AgendamentoId,
            int ProcedimentoId
        )
        {
            this.Id = Id;
            this.AgendamentoId = AgendamentoId;
            this.Agendamento = Agendamento.GetAgendamentos().Find(Agendamento => Agendamento.Id == AgendamentoId);
            this.ProcedimentoId = ProcedimentoId;
            this.Procedimento = Procedimento.GetProcedimentos().Find(Procedimento => Procedimento.Id == ProcedimentoId);
            
            //AgendamentoProcedimentos.Add(this);
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
            Context db = new Context();
            return (from AgendamentoProcedimento in db.AgendamentoProcedimentos select AgendamentoProcedimento).ToList();
        }

        public static void RemoverAgendamentoProcedimento(
            AgendamentoProcedimento agendamentoProcedimento
        )
        {
            Context db = new Context();
            db.AgendamentoProcedimentos.Remove(agendamentoProcedimento);
        }

    }
}
