using System;
using System.Diagnostics;
using SomeSpace;

namespace HelloWorld
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new Simulation(100, 10, new Animal1());
        }
    }

    class Simulation
    {
        public static readonly Random random = new Random();
        readonly List<Individuo> population = new List<Individuo>();
        readonly Specie specie;
        public Simulation(int nrCycles, int popInit, Specie specie)
        {
            this.specie = specie;
            for (int i = 0; i < popInit; i++)
            {
                population.Add(new Individuo(specie));
            }
            for (int i = 0; i < nrCycles; i++)
            {
                if (population.Count == 0)
                {
                    Console.WriteLine("Morreram todos");
                    break;
                }
                nextCycle(new Day());
            }
            foreach (Individuo individuo in population)
            {
                Console.WriteLine(individuo);
            }
        }

        private void nextCycle(Day day)
        {
            Console.WriteLine("Dia: " + day.nrDay + " temperatura: " + day.temperature);
            Console.WriteLine("NR POPULAÇÃO " + population.Count);
            List<Individuo> mortos = new List<Individuo>();
            List<Individuo> novos = new List<Individuo>();

            // Use a for loop to avoid modifying the collection while enumerating it
            for (int i = 0; i < population.Count; i++)
            {
                Individuo individuo = population[i];

                if (individuo.Dies(day))
                {
                    /*                     Console.WriteLine("individuo morreu");
                     */
                    mortos.Add(individuo); // Adiciona à lista de mortos
                }
                else
                {
                    individuo.age++;
                    int numNovos = individuo.specie.GetNrOfKids();
                    for (int j = 0; j < numNovos; j++)
                    {
                        /*                         Console.WriteLine("individuo nasceu");
                         */
                        novos.Add(new Individuo(specie)); // Adiciona à lista de novos
                    }
                }
            }

            // Remove os indivíduos mortos após o loop
            Console.WriteLine("Morreram neste dia: " + mortos.Count + " Nasceram: " + novos.Count);
            foreach (Individuo morto in mortos)
            {
                population.Remove(morto);
            }

            // Adiciona os novos indivíduos após o loop
            population.AddRange(novos);
        }


    }
}