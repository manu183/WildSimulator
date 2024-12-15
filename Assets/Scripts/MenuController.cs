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

    [SerializeField] public TextMeshProUGUI Title; // Arraste no Inspector ou inicialize no código.

    // Chicken
    [SerializeField] Chicken chicken = new Chicken();

    [SerializeField] private TMP_InputField chickenTemperature;
    [SerializeField] private TMP_InputField chickenPregnacyProbability;
    [SerializeField] private TMP_InputField chickenGestation;

    [SerializeField] private TMP_InputField chickenMaximumAvgAge;

    [SerializeField] private TMP_InputField chickenTemperatureTolerance;


    [SerializeField] private TMP_InputField chickenPopulation;

    // Deer
    [SerializeField] Deer deer = new Deer();

    [SerializeField] private TMP_InputField deerTemperature;
    [SerializeField] private TMP_InputField deerPregnacyProbability;
    [SerializeField] private TMP_InputField deerGestation;

    [SerializeField] private TMP_InputField deerMaximumAvgAge;

    [SerializeField] private TMP_InputField deerTemperatureTolerance;
    [SerializeField] private TMP_InputField deerPopulation;

    // Dog
    [SerializeField] Dog dog = new Dog();

    [SerializeField] private TMP_InputField dogTemperature;
    [SerializeField] private TMP_InputField dogPregnacyProbability;
    [SerializeField] private TMP_InputField dogGestation;

    [SerializeField] private TMP_InputField dogMaximumAvgAge;

    [SerializeField] private TMP_InputField dogTemperatureTolerance;
    [SerializeField] private TMP_InputField dogPopulation;

    // Horse
    [SerializeField] Horse horse = new Horse();

    [SerializeField] private TMP_InputField horseTemperature;
    [SerializeField] private TMP_InputField horsePregnacyProbability;
    [SerializeField] private TMP_InputField horseGestation;
    [SerializeField] private TMP_InputField horseMaximumAvgAge;

    [SerializeField] private TMP_InputField horseTemperatureTolerance;
    [SerializeField] private TMP_InputField horsePopulation;


    // Kitty
    [SerializeField] Kitty kitty = new Kitty();

    [SerializeField] private TMP_InputField kittyTemperature;
    [SerializeField] private TMP_InputField kittyPregnacyProbability;
    [SerializeField] private TMP_InputField kittyGestation;
    [SerializeField] private TMP_InputField kittyMaximumAvgAge;

    [SerializeField] private TMP_InputField kittyTemperatureTolerance;
    [SerializeField] private TMP_InputField kittyPopulation;

    // Pinguin
    [SerializeField] Pinguin pinguin = new Pinguin();

    [SerializeField] private TMP_InputField pinguinTemperature;
    [SerializeField] private TMP_InputField pinguinPregnacyProbability;
    [SerializeField] private TMP_InputField pinguinGestation;
    [SerializeField] private TMP_InputField pinguinMaximumAvgAge;

    [SerializeField] private TMP_InputField pinguinTemperatureTolerance;
    [SerializeField] private TMP_InputField pinguinPopulation;

    // Tiger
    [SerializeField] Tiger tiger = new Tiger();

    [SerializeField] private TMP_InputField tigerTemperature;
    [SerializeField] private TMP_InputField tigerPregnacyProbability;
    [SerializeField] private TMP_InputField tigerGestation;
    [SerializeField] private TMP_InputField tigerMaximumAvgAge;

    [SerializeField] private TMP_InputField tigerTemperatureTolerance;
    [SerializeField] private TMP_InputField tigerPopulation;

    private readonly int DEFAULT_POPULATION = 10;




    public void Start()
    {

        //Definir os valores do TextMeshProUGUI com os valores default definidos nas classes
        //Chicken
        chickenTemperature.text = chicken.GetTemperaturaIdeal().ToString();
        chickenPregnacyProbability.text = chicken.GetProbProcriar().ToString();
        chickenGestation.text = chicken.GetTempoGravidez().ToString();
        chickenMaximumAvgAge.text = chicken.GetIdadeMedia().ToString();
        chickenTemperatureTolerance.text=chicken.GetToleracaoTemperatura().ToString();

        chickenPopulation.text = DEFAULT_POPULATION.ToString();

        //Deer
        deerTemperature.text = deer.GetTemperaturaIdeal().ToString();
        deerPregnacyProbability.text = deer.GetProbProcriar().ToString();
        deerGestation.text = deer.GetTempoGravidez().ToString();
        deerMaximumAvgAge.text = deer.GetIdadeMedia().ToString();
        deerTemperatureTolerance.text=deer.GetToleracaoTemperatura().ToString();
        deerPopulation.text = DEFAULT_POPULATION.ToString();

        //Dog
        dogTemperature.text = dog.GetTemperaturaIdeal().ToString();
        dogPregnacyProbability.text = dog.GetProbProcriar().ToString();
        dogGestation.text = dog.GetTempoGravidez().ToString();
        dogMaximumAvgAge.text = dog.GetIdadeMedia().ToString();
        dogTemperatureTolerance.text=dog.GetToleracaoTemperatura().ToString();
        dogPopulation.text = DEFAULT_POPULATION.ToString();


        //Horse
        horseTemperature.text = horse.GetTemperaturaIdeal().ToString();
        horsePregnacyProbability.text = horse.GetProbProcriar().ToString();
        horseGestation.text = horse.GetTempoGravidez().ToString();
        horseMaximumAvgAge.text = horse.GetIdadeMedia().ToString();
        horseTemperatureTolerance.text=horse.GetToleracaoTemperatura().ToString();
        horsePopulation.text = DEFAULT_POPULATION.ToString();

        //Kitty
        kittyTemperature.text = kitty.GetTemperaturaIdeal().ToString();
        kittyPregnacyProbability.text = kitty.GetProbProcriar().ToString();
        kittyGestation.text = kitty.GetTempoGravidez().ToString();
        kittyMaximumAvgAge.text = kitty.GetIdadeMedia().ToString();
        kittyTemperatureTolerance.text=kitty.GetToleracaoTemperatura().ToString();
        kittyPopulation.text = DEFAULT_POPULATION.ToString();

        //Pinguin
        pinguinTemperature.text = pinguin.GetTemperaturaIdeal().ToString();
        pinguinPregnacyProbability.text = pinguin.GetProbProcriar().ToString();
        pinguinGestation.text = pinguin.GetTempoGravidez().ToString();
        pinguinMaximumAvgAge.text = pinguin.GetIdadeMedia().ToString();
        pinguinTemperatureTolerance.text=pinguin.GetToleracaoTemperatura().ToString();
        pinguinPopulation.text = DEFAULT_POPULATION.ToString();

        //Tiger
        tigerTemperature.text = tiger.GetTemperaturaIdeal().ToString();
        tigerPregnacyProbability.text = tiger.GetProbProcriar().ToString();
        tigerGestation.text = tiger.GetTempoGravidez().ToString();
        tigerMaximumAvgAge.text = tiger.GetIdadeMedia().ToString();
        tigerTemperatureTolerance.text=tiger.GetToleracaoTemperatura().ToString();
        tigerPopulation.text = DEFAULT_POPULATION.ToString();


        

    }

    public void saveUserInputs()
    {
        //Chicken
        if (!string.IsNullOrEmpty(chickenTemperature.text))
        {
            chicken.SetTemperaturaIdeal(double.Parse(chickenTemperature.text));
        }
        if (!string.IsNullOrEmpty(chickenPregnacyProbability.text))
        {
            chicken.SetTemperaturaIdeal(double.Parse(chickenPregnacyProbability.text));
        }
        if (!string.IsNullOrEmpty(chickenGestation.text))
        {
            chicken.SetTemperaturaIdeal(int.Parse(chickenGestation.text));
        }

        if (!string.IsNullOrEmpty(chickenMaximumAvgAge.text))
        {
            chicken.SetTemperaturaIdeal(int.Parse(chickenMaximumAvgAge.text));
        }
        if (!string.IsNullOrEmpty(chickenTemperatureTolerance.text))
        {
            chicken.SetTemperaturaIdeal(double.Parse(chickenTemperatureTolerance.text));
        }

        if (!string.IsNullOrEmpty(chickenPopulation.text))
        {
            chicken.SetTemperaturaIdeal(int.Parse(chickenPopulation.text));
        }

        //Deer
        if (!string.IsNullOrEmpty(deerTemperature.text))
        {
            deer.SetTemperaturaIdeal(double.Parse(deerTemperature.text));
        }
        if (!string.IsNullOrEmpty(deerPregnacyProbability.text))
        {
            deer.SetTemperaturaIdeal(double.Parse(deerPregnacyProbability.text));
        }
        if (!string.IsNullOrEmpty(deerGestation.text))
        {
            deer.SetTemperaturaIdeal(int.Parse(deerGestation.text));
        }

        if (!string.IsNullOrEmpty(deerMaximumAvgAge.text))
        {
            deer.SetTemperaturaIdeal(int.Parse(deerMaximumAvgAge.text));
        }
        if (!string.IsNullOrEmpty(deerTemperatureTolerance.text))
        {
            deer.SetTemperaturaIdeal(double.Parse(deerTemperatureTolerance.text));
        }

        if (!string.IsNullOrEmpty(deerPopulation.text))
        {
            deer.SetTemperaturaIdeal(int.Parse(deerPopulation.text));
        }

        //Dog
        if (!string.IsNullOrEmpty(dogTemperature.text))
        {
            dog.SetTemperaturaIdeal(double.Parse(dogTemperature.text));
        }
        if (!string.IsNullOrEmpty(dogPregnacyProbability.text))
        {
            dog.SetTemperaturaIdeal(double.Parse(dogPregnacyProbability.text));
        }
        if (!string.IsNullOrEmpty(dogGestation.text))
        {
            dog.SetTemperaturaIdeal(int.Parse(dogGestation.text));
        }

        if (!string.IsNullOrEmpty(dogMaximumAvgAge.text))
        {
            dog.SetTemperaturaIdeal(int.Parse(dogMaximumAvgAge.text));
        }
        if (!string.IsNullOrEmpty(dogTemperatureTolerance.text))
        {
            dog.SetTemperaturaIdeal(double.Parse(dogTemperatureTolerance.text));
        }

        if (!string.IsNullOrEmpty(dogPopulation.text))
        {
            dog.SetTemperaturaIdeal(int.Parse(dogPopulation.text));
        }

        //Horse
        if (!string.IsNullOrEmpty(horseTemperature.text))
        {
            horse.SetTemperaturaIdeal(double.Parse(horseTemperature.text));
        }
        if (!string.IsNullOrEmpty(horsePregnacyProbability.text))
        {
            horse.SetTemperaturaIdeal(double.Parse(horsePregnacyProbability.text));
        }
        if (!string.IsNullOrEmpty(horseGestation.text))
        {
            horse.SetTemperaturaIdeal(int.Parse(horseGestation.text));
        }

        if (!string.IsNullOrEmpty(horseMaximumAvgAge.text))
        {
            horse.SetTemperaturaIdeal(int.Parse(horseMaximumAvgAge.text));
        }
        if (!string.IsNullOrEmpty(horseTemperatureTolerance.text))
        {
            horse.SetTemperaturaIdeal(double.Parse(horseTemperatureTolerance.text));
        }

        if (!string.IsNullOrEmpty(horsePopulation.text))
        {
            horse.SetTemperaturaIdeal(int.Parse(horsePopulation.text));
        }

        //Kitty
        if (!string.IsNullOrEmpty(kittyTemperature.text))
        {
            kitty.SetTemperaturaIdeal(double.Parse(kittyTemperature.text));
        }
        if (!string.IsNullOrEmpty(kittyPregnacyProbability.text))
        {
            kitty.SetTemperaturaIdeal(double.Parse(kittyPregnacyProbability.text));
        }
        if (!string.IsNullOrEmpty(kittyGestation.text))
        {
            kitty.SetTemperaturaIdeal(int.Parse(kittyGestation.text));
        }

        if (!string.IsNullOrEmpty(kittyMaximumAvgAge.text))
        {
            kitty.SetTemperaturaIdeal(int.Parse(kittyMaximumAvgAge.text));
        }
        if (!string.IsNullOrEmpty(kittyTemperatureTolerance.text))
        {
            kitty.SetTemperaturaIdeal(double.Parse(kittyTemperatureTolerance.text));
        }

        if (!string.IsNullOrEmpty(kittyPopulation.text))
        {
            kitty.SetTemperaturaIdeal(int.Parse(kittyPopulation.text));
        }

        //Pinguin
        if (!string.IsNullOrEmpty(pinguinTemperature.text))
        {
            pinguin.SetTemperaturaIdeal(double.Parse(pinguinTemperature.text));
        }
        if (!string.IsNullOrEmpty(pinguinPregnacyProbability.text))
        {
            pinguin.SetTemperaturaIdeal(double.Parse(pinguinPregnacyProbability.text));
        }
        if (!string.IsNullOrEmpty(pinguinGestation.text))
        {
            pinguin.SetTemperaturaIdeal(int.Parse(pinguinGestation.text));
        }

        if (!string.IsNullOrEmpty(pinguinMaximumAvgAge.text))
        {
            pinguin.SetTemperaturaIdeal(int.Parse(pinguinMaximumAvgAge.text));
        }
        if (!string.IsNullOrEmpty(pinguinTemperatureTolerance.text))
        {
            pinguin.SetTemperaturaIdeal(double.Parse(pinguinTemperatureTolerance.text));
        }

        if (!string.IsNullOrEmpty(pinguinPopulation.text))
        {
            pinguin.SetTemperaturaIdeal(int.Parse(pinguinPopulation.text));
        }

        //Tiger
        if (!string.IsNullOrEmpty(tigerTemperature.text))
        {
            tiger.SetTemperaturaIdeal(double.Parse(tigerTemperature.text));
        }
        if (!string.IsNullOrEmpty(tigerPregnacyProbability.text))
        {
            tiger.SetTemperaturaIdeal(double.Parse(tigerPregnacyProbability.text));
        }
        if (!string.IsNullOrEmpty(tigerGestation.text))
        {
            tiger.SetTemperaturaIdeal(int.Parse(tigerGestation.text));
        }

        if (!string.IsNullOrEmpty(tigerMaximumAvgAge.text))
        {
            tiger.SetTemperaturaIdeal(int.Parse(tigerMaximumAvgAge.text));
        }
        if (!string.IsNullOrEmpty(tigerTemperatureTolerance.text))
        {
            tiger.SetTemperaturaIdeal(double.Parse(tigerTemperatureTolerance.text));
        }

        if (!string.IsNullOrEmpty(tigerPopulation.text))
        {
            tiger.SetTemperaturaIdeal(int.Parse(tigerPopulation.text));
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
            AnimalManager.Instance.AddAnimal(chicken);
        }


        Debug.Log(deer);
        Debug.Log(deerPopulation);
        for (int i = 0; i < int.Parse(deerPopulation.text); i++)
        {
            AnimalManager.Instance.AddAnimal(deer);
        }


        Debug.Log(dog);
        Debug.Log(dogPopulation);
        for (int i = 0; i < int.Parse(dogPopulation.text); i++)
        {
            AnimalManager.Instance.AddAnimal(dog);
        }

        Debug.Log(horse);
        Debug.Log(horsePopulation);
        for (int i = 0; i < int.Parse(horsePopulation.text); i++)
        {
            AnimalManager.Instance.AddAnimal(horse);
        }

        Debug.Log(kitty);
        Debug.Log(kittyPopulation);
        for (int i = 0; i < int.Parse(kittyPopulation.text); i++)
        {
            AnimalManager.Instance.AddAnimal(kitty);
        }

        Debug.Log(pinguin);
        Debug.Log(pinguinPopulation);
        for (int i = 0; i < int.Parse(pinguinPopulation.text); i++)
        {
            AnimalManager.Instance.AddAnimal(pinguin);
        }


        Debug.Log(tiger);
        Debug.Log(tigerPopulation.ToString());
        for (int i = 0; i < int.Parse(tigerPopulation.text); i++)
        {
           AnimalManager.Instance.AddAnimal(tiger);
        }


        Debug.Log("There were " + AnimalManager.Instance.GetAnimals().Count +" animalson AnimalManager! ");
        await Task.Delay(100);
        Debug.Log("Preparado");

        SceneManager.LoadScene("Mundo");
        Debug.Log("Carregado o mundo");
    }
}


