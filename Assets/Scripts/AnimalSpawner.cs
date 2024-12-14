namespace Utils
{
    using System.Collections.Generic;
    using Backend;
    using Backend.Animals;
    using UnityEngine;

    public class AnimalSpawner
    {
        private List<Object> spawnedAnimals; // Armazenar os animais instanciados

        public AnimalSpawner()
        {
            spawnedAnimals = new List<Object>();
        }



        public void SpawnAnimals(Specie animal, int numberOfAnimals)
        {
            if (spawnedAnimals.Count >= 1)
            {
                ClearAnimals();
            }

            GameObject animalPrefab = null;
            if (animal is Backend.Animals.Animal1)
            {
                GameObject tigerPrefab = Resources.Load<GameObject>("Animals_FREE/Prefabs/Tiger_001");

                if (tigerPrefab != null)
                {
                    Debug.Log("Tiger prefab carregado com sucesso!");
                }
                else
                {
                    Debug.LogError("Falha ao carregar o prefab Tiger_001. Verifique o caminho e se ele está na pasta Resources.");
                }




                animalPrefab = tigerPrefab;
            }

            if (animalPrefab == null)
            {
                Debug.LogError("Prefab não encontrado para a espécie fornecida!");
                return;
            }

            if (animalPrefab == null)
            {
                Debug.LogError("Não carrega o GameObject!");
            }
            else
            {

                Debug.Log("Carregou o object!");

                Terrain terrain = Terrain.activeTerrain;
                for (int i = 0; i < numberOfAnimals; i++)
                {
                    Vector3 randomPosition = new Vector3(
                        Random.Range(0, 1000),
                        0,
                        Random.Range(0, 1000)
                    );

                    if (terrain != null)
                    {
                        randomPosition.y = terrain.SampleHeight(randomPosition) + terrain.GetPosition().y;
                    }
                    else
                    {
                        Debug.LogWarning("Nenhum terreno encontrado. Os animais serão spawnados na altura fixa de 0.");
                        randomPosition.y = 0; // Use uma altura fixa se não houver terreno
                    }

                    // Instancia o animal no mapa usando UnityEngine.Object.Instantiate
                    Object spawned = Object.Instantiate(animalPrefab, randomPosition, Quaternion.identity); //guardar na lista animalsSpawned
                    if (spawned == null)
                    {
                        Debug.LogError("Não foi spawnadado o object!");
                    }
                    else
                    {
                        spawnedAnimals.Add(spawned);
                    }
                }

            }
            Debug.Log("There are " + spawnedAnimals.Count + " animals on the field!");
        }

        private void ClearAnimals()
        {
            if (spawnedAnimals != null)
            {
                foreach (var animal in spawnedAnimals)
                {
                    if (animal != null)
                    {
                        Object.Destroy(animal); // Destrói o animal da cena
                    }
                }
            }
            spawnedAnimals.Clear(); //limpar a lista

        }
    }
}
