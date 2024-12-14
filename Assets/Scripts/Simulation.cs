using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Random = System.Random;
namespace Backend
{


    internal class Program
    {
        private static void Main(string[] args)
        {
            // new Simulation(100, 10, new Animais.Animal1());
            Console.WriteLine("Running");
        }
    }

    public class Simulation
    {
        public static readonly Random random = new Random();
        readonly List<Backend.Individuo> population = new List<Individuo>();
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
            UnityEngine.Debug.Log("Was constructed!");        }

        private void nextCycle(Day day)
        {
            Console.WriteLine("Dia: " + day.nrDay + " temperatura: " + day.temperature);
            UnityEngine.Debug.Log("NR POPULAÇÃO " + population.Count);
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



        public void advanceDay(){
            nextCycle(new Day());
        }
    }
}
