using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Backend;
using Backend.Animals;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public static MenuController Instance;

    [SerializeField] public TextMeshProUGUI Title; // Arraste no Inspector ou inicialize no código.

    // Chicken
    [SerializeField] Chicken chicken = new Chicken();

    [SerializeField] private TMP_InputField chickenTemperature;
    [SerializeField] private TMP_InputField chickenPregnacyProbability;
    [SerializeField] private TMP_InputField chickenGestation;
    [SerializeField] private TMP_InputField chickenPopulation;

    // Deer
    [SerializeField] Deer deer = new Deer();

    [SerializeField] private TMP_InputField deerTemperature;
    [SerializeField] private TMP_InputField deerPregnacyProbability;
    [SerializeField] private TMP_InputField deerGestation;
    [SerializeField] private TMP_InputField deerPopulation;

    // Dog
    [SerializeField] Dog dog = new Dog();

    [SerializeField] private TMP_InputField dogTemperature;
    [SerializeField] private TMP_InputField dogPregnacyProbability;
    [SerializeField] private TMP_InputField dogGestation;
    [SerializeField] private TMP_InputField dogPopulation;

    // Horse
    [SerializeField] Horse horse = new Horse();

    [SerializeField] private TMP_InputField horseTemperature;
    [SerializeField] private TMP_InputField horsePregnacyProbability;
    [SerializeField] private TMP_InputField horseGestation;
    [SerializeField] private TMP_InputField horsePopulation;


    // Kitty
    [SerializeField] Kitty kitty = new Kitty();

    [SerializeField] private TMP_InputField kittyTemperature;
    [SerializeField] private TMP_InputField kittyPregnacyProbability;
    [SerializeField] private TMP_InputField kittyGestation;
    [SerializeField] private TMP_InputField kittyPopulation;

    // Pinguin
    [SerializeField] Pinguin pinguin = new Pinguin();

    [SerializeField] private TMP_InputField pinguinTemperature;
    [SerializeField] private TMP_InputField pinguinPregnacyProbability;
    [SerializeField] private TMP_InputField pinguinGestation;
    [SerializeField] private TMP_InputField pinguinPopulation;

    // Tiger
    [SerializeField] Tiger tiger = new Tiger();

    [SerializeField] private TMP_InputField tigerTemperature;
    [SerializeField] private TMP_InputField tigerPregnacyProbability;
    [SerializeField] private TMP_InputField tigerGestation;
    [SerializeField] private TMP_InputField tigerPopulation;

    private readonly int DEFAULT_POPULATION = 10;



    public List<Specie> animalsList;//TimeController vai aceder a esta lista


    void Awake()
    {
        // Verifica se já existe uma instância do Singleton
        if (Instance == null)
        {
            Instance = this; // Se não, define a instância como esta
            DontDestroyOnLoad(gameObject); // Não destruir o objeto ao trocar de cena
        }
        else
        {
            Destroy(gameObject); // Se já houver uma instância, destrua esta
        }
    }

    public void Start()
    {
        //Definir os valores do TextMeshProUGUI com os valores default definidos nas classes

        //Chicken
        chickenTemperature.text = chicken.getTemperaturaIdeal().ToString();
        chickenPregnacyProbability.text = chicken.getProbProcriar().ToString();
        chickenGestation.text = chicken.getTempoGravidez().ToString();
        chickenPopulation.text = DEFAULT_POPULATION.ToString();

        //Deer
        deerTemperature.text = deer.getTemperaturaIdeal().ToString();
        deerPregnacyProbability.text = deer.getProbProcriar().ToString();
        deerGestation.text = deer.getTempoGravidez().ToString();
        deerPopulation.text = DEFAULT_POPULATION.ToString();

        //Dog
        dogTemperature.text = dog.getTemperaturaIdeal().ToString();
        dogPregnacyProbability.text = dog.getProbProcriar().ToString();
        dogGestation.text = dog.getTempoGravidez().ToString();
        dogPopulation.text = DEFAULT_POPULATION.ToString();


        //Horse
        horseTemperature.text = horse.getTemperaturaIdeal().ToString();
        horsePregnacyProbability.text = horse.getProbProcriar().ToString();
        horseGestation.text = horse.getTempoGravidez().ToString();
        horsePopulation.text = DEFAULT_POPULATION.ToString();

        //Kitty
        kittyTemperature.text = kitty.getTemperaturaIdeal().ToString();
        kittyPregnacyProbability.text = kitty.getProbProcriar().ToString();
        kittyGestation.text = kitty.getTempoGravidez().ToString();
        kittyPopulation.text = DEFAULT_POPULATION.ToString();

        //Pinguin
        pinguinTemperature.text = pinguin.getTemperaturaIdeal().ToString();
        pinguinPregnacyProbability.text = pinguin.getProbProcriar().ToString();
        pinguinGestation.text = pinguin.getTempoGravidez().ToString();
        pinguinPopulation.text = DEFAULT_POPULATION.ToString();

        //Tiger
        tigerTemperature.text = tiger.getTemperaturaIdeal().ToString();
        tigerPregnacyProbability.text = tiger.getProbProcriar().ToString();
        tigerGestation.text = tiger.getTempoGravidez().ToString();
        tigerPopulation.text = DEFAULT_POPULATION.ToString();
    }

    public void saveUserInputs()
    {
        //Chicken
        if (!string.IsNullOrEmpty(chickenTemperature.text))
        {
            chicken.setTemperaturaIdeal(double.Parse(chickenTemperature.text));
        }
        if (!string.IsNullOrEmpty(chickenPregnacyProbability.text))
        {
            chicken.setTemperaturaIdeal(double.Parse(chickenTemperature.text));
        }
        if (!string.IsNullOrEmpty(chickenGestation.text))
        {
            chicken.setTemperaturaIdeal(int.Parse(chickenTemperature.text));
        }
        if (!string.IsNullOrEmpty(chickenPopulation.text))
        {
            chicken.setTemperaturaIdeal(int.Parse(chickenTemperature.text));
        }

        //Deer
        if (!string.IsNullOrEmpty(deerTemperature.text))
        {
            deer.setTemperaturaIdeal(double.Parse(deerTemperature.text));
        }
        if (!string.IsNullOrEmpty(deerPregnacyProbability.text))
        {
            deer.setTemperaturaIdeal(double.Parse(deerTemperature.text));
        }
        if (!string.IsNullOrEmpty(deerGestation.text))
        {
            deer.setTemperaturaIdeal(int.Parse(deerTemperature.text));
        }
        if (!string.IsNullOrEmpty(deerPopulation.text))
        {
            deer.setTemperaturaIdeal(int.Parse(deerTemperature.text));
        }

        //Dog
        if (!string.IsNullOrEmpty(dogTemperature.text))
        {
            dog.setTemperaturaIdeal(double.Parse(dogTemperature.text));
        }
        if (!string.IsNullOrEmpty(dogPregnacyProbability.text))
        {
            dog.setTemperaturaIdeal(double.Parse(dogTemperature.text));
        }
        if (!string.IsNullOrEmpty(dogGestation.text))
        {
            dog.setTemperaturaIdeal(int.Parse(dogTemperature.text));
        }
        if (!string.IsNullOrEmpty(dogPopulation.text))
        {
            dog.setTemperaturaIdeal(int.Parse(dogTemperature.text));
        }

        //Horse
        if (!string.IsNullOrEmpty(horseTemperature.text))
        {
            horse.setTemperaturaIdeal(double.Parse(horseTemperature.text));
        }
        if (!string.IsNullOrEmpty(horsePregnacyProbability.text))
        {
            horse.setTemperaturaIdeal(double.Parse(horseTemperature.text));
        }
        if (!string.IsNullOrEmpty(horseGestation.text))
        {
            horse.setTemperaturaIdeal(int.Parse(horseTemperature.text));
        }
        if (!string.IsNullOrEmpty(horsePopulation.text))
        {
            horse.setTemperaturaIdeal(int.Parse(horseTemperature.text));
        }

        //Kitty
        if (!string.IsNullOrEmpty(kittyTemperature.text))
        {
            kitty.setTemperaturaIdeal(double.Parse(kittyTemperature.text));
        }
        if (!string.IsNullOrEmpty(kittyPregnacyProbability.text))
        {
            kitty.setTemperaturaIdeal(double.Parse(kittyTemperature.text));
        }
        if (!string.IsNullOrEmpty(kittyGestation.text))
        {
            kitty.setTemperaturaIdeal(int.Parse(kittyTemperature.text));
        }
        if (!string.IsNullOrEmpty(kittyPopulation.text))
        {
            kitty.setTemperaturaIdeal(int.Parse(kittyTemperature.text));
        }

        //Pinguin
        if (!string.IsNullOrEmpty(pinguinTemperature.text))
        {
            pinguin.setTemperaturaIdeal(double.Parse(pinguinTemperature.text));
        }
        if (!string.IsNullOrEmpty(pinguinPregnacyProbability.text))
        {
            pinguin.setTemperaturaIdeal(double.Parse(pinguinTemperature.text));
        }
        if (!string.IsNullOrEmpty(pinguinGestation.text))
        {
            pinguin.setTemperaturaIdeal(int.Parse(pinguinTemperature.text));
        }
        if (!string.IsNullOrEmpty(pinguinPopulation.text))
        {
            pinguin.setTemperaturaIdeal(int.Parse(pinguinTemperature.text));
        }

        //Tiger
        if (!string.IsNullOrEmpty(tigerTemperature.text))
        {
            tiger.setTemperaturaIdeal(double.Parse(tigerTemperature.text));
        }
        if (!string.IsNullOrEmpty(tigerPregnacyProbability.text))
        {
            tiger.setTemperaturaIdeal(double.Parse(tigerTemperature.text));
        }
        if (!string.IsNullOrEmpty(tigerGestation.text))
        {
            tiger.setTemperaturaIdeal(int.Parse(tigerTemperature.text));
        }
        if (!string.IsNullOrEmpty(tigerPopulation.text))
        {
            tiger.setTemperaturaIdeal(int.Parse(tigerTemperature.text));
        }

    }


    public async void StartSimulation()
    {
        if (Title != null)
        {
            Title.SetText("Começando a simulação...!");
        }
        else
        {
            Debug.LogError("O título não está inicializado.");
            return;
        }

        saveUserInputs(); //guardar os inputs do user


        Debug.Log(chicken);
        Debug.Log(chickenPopulation);
        for (int i = 0; i < int.Parse(chickenPopulation.text); i++)
        {
            animalsList.Add(chicken);
        }


        Debug.Log(deer);
        Debug.Log(deerPopulation);
        for (int i = 0; i < int.Parse(deerPopulation.text); i++)
        {
            animalsList.Add(deer);
        }


        Debug.Log(dog);
        Debug.Log(dogPopulation);
        for (int i = 0; i < int.Parse(dogPopulation.text); i++)
        {
            animalsList.Add(dog);
        }

        Debug.Log(horse);
        Debug.Log(horsePopulation);
        for (int i = 0; i < int.Parse(horsePopulation.text); i++)
        {
            animalsList.Add(horse);
        }

        Debug.Log(kitty);
        Debug.Log(kittyPopulation);
        for (int i = 0; i < int.Parse(kittyPopulation.text); i++)
        {
            animalsList.Add(kitty);
        }

        Debug.Log(pinguin);
        Debug.Log(pinguinPopulation);
        for (int i = 0; i < int.Parse(pinguinPopulation.text); i++)
        {
            animalsList.Add(pinguin);
        }


        Debug.Log(tiger);
        Debug.Log(tigerPopulation.ToString());
        for (int i = 0; i < int.Parse(tigerPopulation.text); i++)
        {
            animalsList.Add(tiger);
        }

        await Task.Delay(1000);
        Debug.Log("Preparado");

        SceneManager.LoadScene("Mundo");
        Debug.Log("Carregado o mundo");
    }
}


