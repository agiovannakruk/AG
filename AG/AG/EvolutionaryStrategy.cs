using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG
{
    internal class EvolutionaryStrategy
    {
        Individual current, next;
        int generations;

        public EvolutionaryStrategy(Individual x, int generations)
        {
            this.current = x;
            this.generations = generations;
        }
        public void findSolutions()
        {
            int i = 0, movement;
            double fxPrevious = 1000, fxCurrent = 1000;

            while(i < generations)
            {
                Console.WriteLine("Iteração: " + i + " " +  fxPrevious);
                movement = current.mutation();

                fxCurrent = current.fx;

                if(fxCurrent > fxPrevious)
                {
                    current.reverseMutation(movement);
                }
                else
                {
                    fxPrevious = current.fx;    
                }

                i++;
            }
            Console.WriteLine("Solução: ");
            current.print();

        }
    }
}
