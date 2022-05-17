using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG
{
    internal class GeneticAlgorithm
    {
        public Population Population;
        public int generations;
        Random random;

        public GeneticAlgorithm (Population p, int generations)
        {
            random = new Random();
            this.generations = generations;
            this.Population = p;
        }

        public void findSolution()
        {
            int i = 0, x, y;
            while(i < generations)
            {
                Console.WriteLine("Iteração: " + i + " " + Population.bestIndividuals.fx);
                Population.mutation();
                x = random.Next(Population.n);
                y = random.Next(Population.n);

                Population.recombinacao(Population.individuals[x], Population.individuals[y]);
                i++;
            }

            Console.WriteLine("Solução");
            Population.bestIndividuals.print();
        }

    }
}
