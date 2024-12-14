namespace Utils
{
    using Backend;
    using UnityEngine;

    public class AnimalSpawner
    {
        private GameObject animalPrefab;  // O prefab do animal
        private int numberOfAnimals; // Quantidade de animais para spawnar

        private Vector3 spawnAreaMin; // Posição mínima da área
        private Vector3 spawnAreaMax; // Posição máxima da área

        public AnimalSpawner(Specie animal, int numberOfAnimals, Vector3 spawnAreaMin, Vector3 spawnAreaMax)
        {
            // Verifica o tipo da espécie e carrega o prefab correspondente
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
                // Debug.LogError("Prefab não encontrado para a espécie fornecida!");
                return;
            }

            this.numberOfAnimals = numberOfAnimals; // Armazena o número de animais da instância
            this.spawnAreaMin = spawnAreaMin;
            this.spawnAreaMax = spawnAreaMax;
        }

        public void SpawnAnimals()
        {
            if (animalPrefab == null)
            {
                Debug.LogError("Nenhum prefab foi carregado, abortando spawn!");
                return;
            }

            for (int i = 0; i < numberOfAnimals; i++)
            {
                Vector3 randomPosition = new Vector3(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y),
                    100
                );

                // Instancia o animal no mapa usando UnityEngine.Object.Instantiate
                Object.Instantiate(animalPrefab, randomPosition, Quaternion.identity);

            }
            Debug.Log("Animals were spawned!");
        }
    }
}
