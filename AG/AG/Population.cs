using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG
{
    internal class Population
    {
        public Individual[] individuals;
        public int n;
        public int bits;
        public Individual bestIndividuals;
        public double smallFunctionX = 10000;
        public double bestIndex;
       
        public Population(int n, int bits)
        {
            this.n = n;
            this.bits = bits;

            individuals = new Individual[n];
            bestIndividuals = new Individual(bits);

            for(int i = 0; i < n; i++)
            {
                individuals[i] = new Individual(bits);
                individuals[i].generateIndividual();
                individuals[i].update();

                if (individuals[i].fx < smallFunctionX)
                {
                    smallFunctionX = individuals[i].fx;
                    bestIndex = i;
                }
            }

            bestIndividuals.clone(individuals[(int)bestIndex]);
        }
        public void print()
        {
            for(int i = 0; i < n; i++)
            {
                individuals[(int)i].print();
            }
        }
        public void mutation()
        {
            smallFunctionX = bestIndividuals.fx;
            for(int i = 0; i < n; i++)
            {
                individuals[((int)i)].mutation();
                if(individuals[i].fx < smallFunctionX)
                {
                    smallFunctionX=individuals[i].fx;
                    bestIndex=i;
                }
            }

            if(smallFunctionX < bestIndividuals.fx)
            {
                bestIndividuals.clone(individuals[(int)bestIndex]);
            }
        }
        public void recombinacao(Individual a, Individual b)
        {
            Random random = new Random();
            int corte, aux;
            bestIndex = 0;
            smallFunctionX = bestIndividuals.fx;
            corte = random.Next(bits);
            for(int i = 0; i < bits; i++)
            {
                aux = b.gene[i];
                b.gene[i] = a.gene[i];
                a.gene[i] = aux;
            }
            a.update();
            if(a.fx < smallFunctionX)
            {
                smallFunctionX = a.fx;
                bestIndex = 1;
            }
            b.update();

            if(b.fx < smallFunctionX)
            {
                smallFunctionX = b.fx;
                bestIndex = 2;
            }
            if(bestIndex == 1)
            {
                bestIndividuals.clone(a);
            }
            else if(bestIndex == 2)
            {
                bestIndividuals.clone(b);
            }
        }
        
    }
}
