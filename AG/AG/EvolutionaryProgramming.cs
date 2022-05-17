using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG
{
    internal class EvolutionaryProgramming
    {
        public Population population;
        public int generations;

        public EvolutionaryProgramming(Population population, int generations)
        {
            this.population = population;
            this.generations = generations;
        }
        public void findSolution()
        {
            int i = 0;

            while(i < generations)
            {
                Console.WriteLine("Interação " + i + " : " + population.bestIndividuals.fx);
                population.mutation();
                i++;
            }

            Console.WriteLine();
            Console.WriteLine("Solução ");
            population.bestIndividuals.print();
        }
    }
}
