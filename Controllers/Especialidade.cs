using System;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Controllers
{
    public class EspecialidadeController
    {
        public static Especialidade InserirEspecialidade(
            string Descricao,
            string Tarefas
        )
        {
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new Exception("Descrição inválida");
            }

            if (String.IsNullOrEmpty(Tarefas))
            {
                throw new Exception("Tarefa inválida");
            }

            return new Especialidade(Descricao, Tarefas);
        }

        public static Especialidade AlterarEspecialidade(
            int Id,
            string Descricao,
            string Tarefas
        )
        {
            Especialidade especialidade = GetEspecialidade(Id);

            if (!String.IsNullOrEmpty(Descricao))
            {
                especialidade.Descricao = Descricao;
            }

            if (!String.IsNullOrEmpty(Tarefas))
            {
                especialidade.Tarefas = Tarefas;
            }

            return especialidade;
        }
        public static Especialidade ExcluirEspecialidade(
            int Id
        )
        {
            Especialidade especialidade = GetEspecialidade(Id);
            Especialidade.RemoverEspecialidade(especialidade);
            return especialidade;
        }
        public static List<Especialidade> VisualizarEspecialidade()
        {
            return Especialidade.GetEspecialidades();
        }
        public static Especialidade GetEspecialidade(
            int Id
        )
        {
            Especialidade especialidade = (
                from Especialidade in Especialidade.GetEspecialidades()
                    where Especialidade.Id == Id
                    select Especialidade
            ).First();

            if (especialidade == null)
            {
                throw new Exception("Especialidade não encontrada.");
            }

            return especialidade;
        }
    }
}
