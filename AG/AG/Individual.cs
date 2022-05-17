using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AG
{
    internal class Individual
    {
        int bits;
        public int[] gene = null;
        public double dec, x, fx;
        int r;


        public int gerar()
        {
            int num = 0;
            Random r = new Random();
            num = r.Next(0, 10);
            return num;
        }
        public Individual(int b)
        {
            bits = b;
            gene = new int[b];
             r = gerar();
            
        }
        public int[] generateIndividual()
        {
                        
            for(int i = 0; i < bits; i++)
            {
                gene[i] = r%2;

            }
                       
            return gene;      
        }

        public void print()
        {
            calculateExtremePoints();
            Console.WriteLine();
            for (int i = 0; i < bits; i++)
            {
                Console.Write(gene[i] + " ");
            }
            Console.WriteLine();
           
            
            Console.WriteLine("Decimal:  " + dec);
            Console.WriteLine("x = " + Math.Round(x,2));
            Console.WriteLine("f(x)  = " + Math.Round(fx, 2));
            Console.WriteLine();
        }

        public void binaryToDecimal()
        {
            dec = 0;
            int i;
            for (int j = 0; j < bits; j++)
            {
                i = bits - 1 - j;
                dec += gene[j]*Math.Pow(2.0, i);
            }
        }

        public void calculateX()
        {
            x = 6.0 * dec / (Math.Pow(2.0, bits) - 1);
        }

        public void calculateFx()
        {
            fx = x * x - 5.0 * x + 6.0;
        }

        void calculateExtremePoints()
        {
            double a = 1, b = -5, c = 6;
            double valueX, valueY;
            valueX = ((-b) / (2 * a));
            double fisrt = - ((b * b) - (4 * a * c));
            double second = (4 * a);
            valueY = fisrt / second;

            Console.WriteLine("Valores Extremos da Função");

            Console.WriteLine("X : " + valueX);
            Console.WriteLine("Y : " + valueY);
        
        }

        public int mutation()
        {
            int i;
            Random r = new Random();
            i = r.Next(bits);
            if(gene[i] == 0) gene[i] = 1;   
            else gene[i] = 1;

            update();   

            return i;
        }

        public void reverseMutation(int position)
        {
            int i;
            i = position;
            if (gene[i] == 0) gene[i] = 1;
            else gene[i] = 0;

            update();
        }

        public void update()
        {
            binaryToDecimal();
            calculateX();
            calculateFx();  
        }

        public void clone(Individual individual)
        {
            for(int i = 0; i < bits; i++)
            {
                gene[i] = individual.gene[i];
            }

            dec = individual.dec;
            x = individual.x;
            fx = individual.fx;
            r = individual.r;
        }


    }
}
