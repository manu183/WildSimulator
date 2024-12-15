namespace Backend
{

    using System;
    using System.Collections.Generic;
    using Random = System.Random;
    using Backend.Animals;
    using Utils;
    using System.Diagnostics;

    internal class Program
    {
        private static void Main(string[] args)
        {
            // new Simulation(100, 10, new Animal1());
        }
    }

    class Simulation
    {
        public static readonly Random random = new Random();
        readonly List<Individuo> population = new List<Individuo>();

        private Day currentDay;

        private int currentDayIndex = 0;

        private AnimalSpawner animalSpawner = new AnimalSpawner();

        public Simulation(int nrCycles, List<Specie> animals)
        {
            for (int i = 0; i < animals.Count; i++)
            {
                // population.Add(new Individuo(specie));
            }
            foreach (Specie animal in animals)
            {
                // Console.WriteLine(individuo);
                population.Add(new Individuo(animal));
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
            currentDay = day;
            Console.WriteLine("Dia: " + day.nrDay + " temperatura: " + day.temperature);
            Console.WriteLine("NR POPULAÇÃO " + population.Count);
            List<Individuo> mortos = new List<Individuo>();
            List<Individuo> novos = new List<Individuo>();

            //Apagar os animais spawnados no ciclo anteriori
            animalSpawner.ClearAnimals();

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
                    int numNovos = individuo.MakeChildren();
                    for (int j = 0; j < numNovos; j++)
                    {
                        /*                         Console.WriteLine("individuo nasceu");
                         */
                        novos.Add(new Individuo(individuo.specie)); // Adiciona à lista de novos
                    }
                }

                //Spawnar o animal
                animalSpawner.SpawnAnimal(individuo.specie);
            }

            // Remove os indivíduos mortos após o loop
            Console.WriteLine("Morreram neste dia: " + mortos.Count + " Nasceram: " + novos.Count);
            UnityEngine.Debug.Log("Morreram neste dia: " + mortos.Count + " Nasceram: " + novos.Count);
            population.RemoveAll(x => x.died);

            // Adiciona os novos indivíduos após o loop
            population.AddRange(novos);
        }


        public void NextDay()
        {   
            if(currentDayIndex+1>=100){
                UnityEngine.Debug.Log("Acabou a Simulação!");
                return;
            }
            nextCycle(new Day());
            currentDayIndex++;
        }

        public int GetTotalPopulation()
        {
            return population.Count;
        }


        public int GetPopulation(Specie specie)
        {
            int total = 0;
            foreach (Individuo individuo in population)
            {
                if (individuo.specie.GetType() == specie.GetType())
                {
                    total++;
                }
            }
            return total;
        }

        public double GetTemperature()
        {
            return currentDay.temperature;
        }

        public int GetDisaster(){
            return currentDay.disasterType;
        }

    }
}





