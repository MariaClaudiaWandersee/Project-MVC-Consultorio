using System.Collections.Generic;

namespace Models
{
    public class Especialidade
    {
        public static int ID = 0;
        private static List<Especialidade> Especialidades = new List<Especialidade>();
        public int Id { set; get; }
        public string Descricao { set; get; }
        public string Tarefas { set; get; }

        public override string ToString()
        {
            return base.ToString()
                + $"\nDescricao: {this.Descricao}" 
                + $"\nTarefas {this.Tarefas}";
        }
        public Especialidade(
            string Descricao,
            string Tarefas
        ) : this(++ID, Descricao, Tarefas)
        {
        }

        private Especialidade(
            int Id,
            string Descricao,
            string Tarefas
        )
       {
            this.Id = Id;
            this.Descricao = Descricao;
            this.Tarefas = Tarefas;

            Especialidades.Add(this);
        }


        public static List<Especialidade> GetEspecialidades()
        {
            return Especialidades;
        }

        public static void RemoverEspecialidade(Especialidade especialidade)
        {
            Especialidades.Remove(especialidade);
        }

    }
}
