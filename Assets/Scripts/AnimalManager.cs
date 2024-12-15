using UnityEngine;
using System.Collections.Generic;
using Backend;

public class AnimalManager : MonoBehaviour
{
    // Singleton pattern
    public static AnimalManager Instance { get; private set; }

    // Lista de espécies
    public List<Specie> animals = new List<Specie>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Método para adicionar um animal
    public void AddAnimal(Specie animal)
    {
        animals.Add(animal);

    }

    // Método para acessar a lista de animais
    public List<Specie> GetAnimals()
    {
        return animals;
    }

    // Método para limpar a lista de animais
    public void ClearAnimals()
    {
        animals.Clear();
    }

    private void OnDestroy()
    {
        // Se esta instância for a singleton, limpe a referência
        if (Instance == this)
        {
            Instance = null;
        }
    }
}