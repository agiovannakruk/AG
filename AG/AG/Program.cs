using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AG
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int b = 10;
            int i = 0;
            Individual x = new Individual(b);

            /*
            EvolutionaryStrategy evolutionaryStrategy = new EvolutionaryStrategy(x, 50);
            evolutionaryStrategy.findSolutions();
            */
            //Population population = new Population(5, 10);

            //EvolutionaryProgramming programming = new EvolutionaryProgramming(population, 10);
            /*
            
            while(i < 1)
            {
                Console.WriteLine("Rodada: " + i);
                Console.WriteLine();
                population = new Population(5, 10);
                programming = new EvolutionaryProgramming(population, 10);
                programming.findSolution();
                Console.WriteLine("_________________________________________________");
                i++;
            }
            */

            Population population = new Population(5, 10);
            GeneticAlgorithm geneticAlgorithm = new GeneticAlgorithm(population, 100);
            geneticAlgorithm.findSolution();
            
             
        }
    }
}
