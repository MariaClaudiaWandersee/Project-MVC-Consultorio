using System;
using Controllers;
using Models;

namespace Views
{
    public class ProcedimentoView
    {
        public static void InserirProcedimento()
        {
            Console.WriteLine("Digite o Nome do Procedimento: ");
            string Nome = Console.ReadLine();
            Console.WriteLine("Digite o Preço do Procedimento: ");
            double Preco = Convert.ToDouble(Console.ReadLine());

            try
            {
                Preco = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Preço inválido.");
            }

            ProcedimentoController.InserirProcedimento(
                Nome,
                Preco
            );

        }

        public static void AlterarProcedimento()
        {
            int Id = 0;
            double Preco = 0;
            string Nome = "";
            Console.WriteLine("Digite o ID do Procedimento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            Console.WriteLine("Digite o Nome do Procedimento: ");
            Nome = Console.ReadLine();

            Console.WriteLine("Digite o Preço do Procedimento: ");
            try
            {
                Preco = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Preço inválido.");
            }
            
            Console.WriteLine("Digite a Especialidade do Denstista: ");
            string Especialidade = Console.ReadLine();

            ProcedimentoController.AlterarProcedimento(
                Id,
                Nome,
                Preco
            );

        }

        public static void ExcluirProcedimento()
        {
            int Id = 0;
            Console.WriteLine("Digite o ID do Procedimento: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("ID inválido.");
            }
            
            ProcedimentoController.ExcluirProcedimento(
                Id
            );

        }

        public static void ListarProcedimentos()
        {
            foreach (Procedimento item in ProcedimentoController.VisualizarProcedimento())
            {
                Console.WriteLine(item);
            }
        }
    }
}
