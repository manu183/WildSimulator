namespace Utils
{
    using Backend;
    using UnityEngine;

    public class SpawnerManager : MonoBehaviour
    {
        public Specie animalSpecie; // Tipo de espécie
        public int numberOfAnimals = 10; // Número de animais a spawnar

        private void Start()
        {
            Vector3 spawnMin = new Vector3(-1000, 0, 0); // Área mínima
            Vector3 spawnMax = new Vector3(1000, 0, 0);  // Área máxima

            // Cria uma instância de AnimalSpawner com o número de animais definido
            AnimalSpawner spawner = new AnimalSpawner(animalSpecie, numberOfAnimals, spawnMin, spawnMax);

            // Chama o método de spawn
            spawner.SpawnAnimals();
        }
    }
}
