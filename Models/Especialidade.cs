using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Repository;

namespace Models
{
    public class Especialidade
    {
        public int Id { set; get; }
        [Required]
        public string Descricao { set; get; }
        [Required]
        public string Tarefas { set; get; }

        public override string ToString()
        {
            return base.ToString()
                + $"\nDescricao: {this.Descricao}" 
                + $"\nTarefas {this.Tarefas}";
        }
        public Especialidade()
        {}

        private Especialidade(
            int Id,
            string Descricao,
            string Tarefas
        )
        {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Tarefas = Tarefas;
            
            Context db = new Context();
            db.Especialidades.Add(this);
            db.SaveChanges();
        }


        public static List<Especialidade> GetEspecialidades()
        {
            Context db = new Context();
            return (from Especialidade in db.Especialidades select Especialidade).ToList();
        }

        public static void RemoverEspecialidade(Especialidade especialidade)
        {
            Context db = new Context();
            db.Especialidades.Remove(especialidade);
        }

    }
}
