using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Repository;

namespace Models
{
    public class Agendamento
    {
    
        public int Id { set; get; }
        [Required]
        public int PacienteId { set; get; }
        [Required]
        public Paciente Paciente { get; }
        [Required]
        public int DentistaId { set; get; }
        [Required]
        public Dentista Dentista { get; }
        [Required]
        public int SalaId { set; get; }
        [Required]
        public Sala Sala { get; }
        [Required]
        public DateTime Data { set; get; }
        [Required]
        public string Procedimento { set; get; }
        [Required]
        public bool Confirmado { set; get; }

        public Agendamento(
            int PacienteId,
            int DentistaId,
            int SalaId,
            DateTime Data,
            string Procedimento
        )
        {}

        private Agendamento(
            int Id,
            int PacienteId,
            int DentistaId,
            int SalaId,
            DateTime Data,
            string Procedimento
        )
        {
            this.Id = Id;
            this.PacienteId = PacienteId;
            this.Paciente = Paciente.GetPacientes().Find(Paciente => Paciente.Id == PacienteId);
            this.DentistaId = DentistaId;
            this.Dentista = Dentista.GetDentistas().Find(Dentista => Dentista.Id == DentistaId);
            this.SalaId = SalaId;
            this.Sala = Sala.GetSalas().Find(Sala => Sala.Id == SalaId);
            this.Data = Data;
            this.Procedimento = Procedimento;
            Context db = new Context();
            db.Agendamentos.Add(this);
            db.SaveChanges();

        }

        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\nPaciente: {this.Paciente.Nome}"
                + $"\nDentista: {this.Dentista.Nome}"
                + $"\nSala: {this.Sala.Numero}"
                + $"\nData: {this.Data}"
                + $"\nProcedimento: {this.Procedimento}"
                + $"\nConfirmado: {(this.Confirmado ? "Sim" : "Não")}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (!Agendamento.ReferenceEquals(obj, this))
            {
                return false;
            }
            Agendamento it = (Agendamento) obj;
            return it.Id == this.Id;
        }
        public static List<Agendamento> GetAgendamentos()
        {
            Context db = new Context();
            return (from Agendamento in db.Agendamentos select Agendamento).ToList();
        }

        public static void RemoverAgendamento(
            Agendamento agendamento
        )
        {
            Context db = new Context();
            db.Agendamentos.Remove(agendamento);
        }

    }
}
