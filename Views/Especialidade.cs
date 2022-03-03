using System;
using Controllers;
using Models;

namespace Views
{
    public class EspecialidadeView
    {
        public static void InserirEspecialidade()
        {
            Console.WriteLine("Digite descrição da especialidade: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Digite o detalhamento da Especialidade: ");
            string Tarefa = Console.ReadLine();
            Console.WriteLine("Digite a Especialidade do Denstista: ");
            string Especialidade = Console.ReadLine();

            EspecialidadeController.InserirEspecialidade(
                Descricao,
                Tarefa
            );

        }

        public static void AlterarEspecialidade()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID da Especialidade: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            Console.WriteLine("Digite o descrição da Especialidade: ");
            string Descricao = Console.ReadLine();
            Console.WriteLine("Digite o detalhamento da Especialidade: ");
            string Tarefas = Console.ReadLine();
            /*try
            {
                Salario = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Salário inválido.");
            }
            Console.WriteLine("Digite a Especialidade do Denstista: ");
            string Especialidade = Console.ReadLine();

            DentistaController.AlterarDentista(
                Id,
                Nome,
                Cpf
            );*/

        }

        public static void ExcluirEspecialidade()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID da Especialidade: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            EspecialidadeController.ExcluirEspecialidade(
                Id
            );

        }

        public static void ListarEspecialidades()
        {
            foreach (Especialidade item in EspecialidadeController.VisualizarEspecialidade())
            {
                Console.WriteLine(item);
            }
        }
    }
}
