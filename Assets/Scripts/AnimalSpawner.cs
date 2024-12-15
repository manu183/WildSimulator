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

        public void SpawnAnimal(Specie animal)
        {   

            SpawnAnimals(animal,1);
            
        }

        private void SpawnAnimals(Specie animal, int numberOfAnimals)
        {   

            GameObject animalPrefab = null;

            
            if (animal is Backend.Animals.Chicken)
            {
                animalPrefab = Resources.Load<GameObject>("Animals_FREE/Prefabs/Chicken_001");
            }else if(animal is Backend.Animals.Deer){
                 animalPrefab = Resources.Load<GameObject>("Animals_FREE/Prefabs/Deer_001");
            }else if(animal is Backend.Animals.Dog){
                 animalPrefab = Resources.Load<GameObject>("Animals_FREE/Prefabs/Dog_001");
            }else if(animal is Backend.Animals.Horse){
                 animalPrefab = Resources.Load<GameObject>("Animals_FREE/Prefabs/Horse_001");
            }else if(animal is Backend.Animals.Kitty){
                 animalPrefab = Resources.Load<GameObject>("Animals_FREE/Prefabs/Kitty_001");
            }else if(animal is Backend.Animals.Pinguin){
                 animalPrefab = Resources.Load<GameObject>("Animals_FREE/Prefabs/Pinguin_001");
            }else if(animal is Backend.Animals.Tiger){
                 animalPrefab = Resources.Load<GameObject>("Animals_FREE/Prefabs/Tiger_001");
            }


            if (animalPrefab == null)
            {
                Debug.LogError("Não carrega o GameObject" + animal.GetType()+"!");
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

        public void ClearAnimals()
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
