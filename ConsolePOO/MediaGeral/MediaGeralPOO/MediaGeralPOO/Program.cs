using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaGeralPOO
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "### Media Geral dos Alunos ###";

            Console.Write("Informe o numero de alunos: ");
            int nAlunos = int.Parse(Console.ReadLine());

            Alunos[] alunos = new Alunos[nAlunos];

            for (int i = 0; i < alunos.Length; i++)
            {
                Console.Clear();
                Console.Write("Aluno " + (i + 1)+ " Nome..: ");
                string nome = Console.ReadLine();

                Console.Write("Aluno " + (i + 1) + " Provas: ");
                int provas = int.Parse(Console.ReadLine());

                alunos[i] = new Alunos(nome, provas);
                Console.WriteLine();

                Console.WriteLine("Insira as notas do aluno: " + nome);
                alunos[i].InserirNotas();
            }
            Console.Clear();

            double mediaGeral = 0;

            foreach (Alunos alunos1 in alunos)
            {
                Console.WriteLine("Aluno: " + alunos1.Nome);
                Console.WriteLine("Media: "+ alunos1.Media);
                Console.WriteLine();


                mediaGeral += alunos1.Media;
            }

            double resultadoFinal = mediaGeral/alunos.Length;
            Console.WriteLine("Media geral: " + resultadoFinal);
            Console.ReadKey();
        }
    }
}
