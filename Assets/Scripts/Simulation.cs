namespace Backend
{

    using System;
    using System.Collections.Generic;
    using Random = System.Random;
    using Backend.Animals;

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
            // for (int i = 0; i < nrCycles; i++)
            // {
            //     if (population.Count == 0)
            //     {
            //         Console.WriteLine("Morreram todos");
            //         break;
            //     }
            //     nextCycle(new Day());
            // }
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
            population.RemoveAll(x => x.died);

            // Adiciona os novos indivíduos após o loop
            population.AddRange(novos);
        }

        public void nextDay()
        {
            nextCycle(new Day());
        }
    
        public int getNumOfAnimals(){
            return population.Count;
        }
    }

}



