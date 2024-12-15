using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Backend;
using Backend.Animals;
using Utils;
using System.Collections.Generic;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using System.Threading;

public class TimeController : MonoBehaviour
{
    [SerializeField] private Slider timeSlider;         // Referência ao Slider
    [SerializeField] private TextMeshProUGUI toggleButtonText; // Referência ao texto do botão

    [SerializeField] private float baseDayDuration = 10f;  // Duração base de um dia em segundos (10 segundos)



    //Dados estatística em tempo real

    [SerializeField] private TextMeshProUGUI currentDayProgressText; // Texto para mostrar a fração de dia passado

    [SerializeField] private TextMeshProUGUI currentTotalAnimals; // Texto para mostrar o número atual de animais
    [SerializeField] private TextMeshProUGUI timeText;  // Referência ao texto do tempo
    [SerializeField] private TextMeshProUGUI speedText; // Texto para mostrar a velocidade atual

    [SerializeField] private TextMeshProUGUI desastreNatural; // Texto para mostrar a fração de dia passado


    [SerializeField] private TextMeshProUGUI dayTemperature; // Texto para mostrar a fração de dia passado
    [SerializeField] private TextMeshProUGUI chickenPopulation; // Texto para mostrar a fração de dia passado
    [SerializeField] private TextMeshProUGUI deerPopulation; // Texto para mostrar a fração de dia passado
    [SerializeField] private TextMeshProUGUI dogPopulation; // Texto para mostrar a fração de dia passado
    [SerializeField] private TextMeshProUGUI horsePopulation; // Texto para mostrar a fração de dia passado
    [SerializeField] private TextMeshProUGUI kittyPopulation; // Texto para mostrar a fração de dia passado
    [SerializeField] private TextMeshProUGUI pinguinPopulation; // Texto para mostrar a fração de dia passado
    [SerializeField] private TextMeshProUGUI tigerPopulation; // Texto para mostrar a fração de dia passado



    private Simulation simulation;

    [SerializeField] private SunlightController sunlightController;



    // Enum com todas as velocidades possíveis de tempo
    private enum Speed
    {
        Pause = 0,
        x1 = 1,
        x2 = 2,
        x5 = 5,
        x10 = 10,
        x100 = 100,
        x200 = 200,

        x1000 =1000
    }

    [SerializeField] private Speed currentSpeed = Speed.x1;
    private float currentDayProgress = 0f;
    private int currentDay = 1;  // Começa no Dia 1

    private static readonly int MAX_DAYS =100;


    void Start()
    {
        Debug.Log("Hello World!");

        // Configurações iniciais do slider
        if (timeSlider != null)
        {
            timeSlider.minValue = 0f;
            timeSlider.maxValue = MAX_DAYS;  // Progresso do dia de 0 a 100 dias
        }
      

        List<Specie> animals =  AnimalManager.Instance.GetAnimals();
        Debug.Log("AnimalManager has "+animals.Count+ " animals!");
        Debug.Log("Animal Manager não está nulo!");
        simulation = new Simulation(MAX_DAYS, animals);

        

        UpdateTimeText();
        UpdateSpeedText();

        simulation.NextDay(); //Calcular o primeiro dia
        UpdateAllStats(); //Atualiza as estatísticas do ecrã
    }

    void Update() //É chamada a cada frame
    {
        if (currentSpeed != Speed.Pause)
        {
            float timeBetweenFrames = Time.deltaTime;
            // Avança o progresso do dia
            currentDayProgress += (1 / baseDayDuration) * timeBetweenFrames * (int)currentSpeed;
            
            sunlightController.currentDayProgress = currentDayProgress;



            // Verifica se um dia foi completado
            if (currentDayProgress >= 1f)
            {
                currentDayProgress = 0f;
                // currentDay++;
                AdvanceDay();
                
            }

            // Atualiza o slider
            if (timeSlider != null)
                timeSlider.value = currentDayProgress;

            UpdateTimeText();
            UpdateCurrentDayProgressText();
        }
    }

    // Aumenta a velocidade do tempo
    public void IncreaseTimeSpeed()
    {
        // Navega pelas velocidades, excluindo Pause
        int currentSpeedIndex = (int)currentSpeed;
        int maxSpeedIndex = Enum.GetValues(typeof(Speed)).Length-1;

        if (currentSpeedIndex < maxSpeedIndex)
        {
            currentSpeed = (Speed)(currentSpeedIndex + 1);
            UpdateSpeedText();
        }
    }

    // Diminui a velocidade do tempo
    public void DecreaseTimeSpeed()
    {
        // Navega pelas velocidades, com limite mínimo em Pause
        int currentSpeedIndex = (int)currentSpeed;

        if (currentSpeedIndex > 0)
        {
            currentSpeed = (Speed)(currentSpeedIndex - 1);
            UpdateSpeedText();
        }
    }

    // Atualiza o texto de velocidade
    private void UpdateSpeedText()
    {
        string[] velocity = Enum.GetNames(typeof(Speed));
        int currentSpeedIndex = (int)currentSpeed;
        if (speedText != null)
        {
            speedText.text = currentSpeed == Speed.Pause ? "Pause" : velocity[currentSpeedIndex];
        }
    }

    // Função para pausar/despausar o tempo
    public void ToggleTimePause()
    {
        // Alterna entre Pause e x1
        currentSpeed = currentSpeed == Speed.Pause ? Speed.x1 : Speed.Pause;

        toggleButtonText.SetText(currentSpeed == Speed.Pause ? "Play" : "Stop");

        UpdateSpeedText();
    }

    // Função para avançar um dia

    private void AdvanceDay()
    {   
        if(currentDay+1<=MAX_DAYS){
            currentDay++;
            simulation.NextDay();
            UpdateAllStats(); // As estatísticas são atualizadas a cada dia, com exceção da hora e currentDay progress
        }else{
            Debug.Log("Acabaram os dias!");
            currentSpeed = Speed.Pause;
        }

    }



    // Atualiza o texto do tempo
    private void UpdateTimeText()
    {
        if (timeText != null)
        {
            // Calcula as horas do dia (0-24)
            float hours = currentDayProgress * 24f;
            int wholeHours = Mathf.FloorToInt(hours);
            int minutes = Mathf.FloorToInt((hours - wholeHours) * 60f);

            // Formato: "Dia X - HH:MM"
            timeText.text = $"Dia {currentDay} - {wholeHours:D2}:{minutes:D2}";
        }

    }

    private void UpdateCurrentDayProgressText()
    {
        if (currentDayProgressText != null)
        {
            currentDayProgressText.text = "Day progress:" + (currentDayProgress*100).ToString("F2") + "%";
        }

    }

    private string GetDisasterName() {
    int disasterType = simulation.GetDisaster();

    switch (disasterType) {
        case 1:
            return "None";
        case 2:
            return "Fire";
        case 3:
            return "Earthquake";
        case 4:
            return "Tsunami";
        default:
            return "Unknown"; // Para o caso de um desastre não mapeado
    }
}




    private void UpdateAllStats(){

        dayTemperature.SetText("Temperature:" + simulation.GetTemperature().ToString("F2") + "ºC");
        desastreNatural.SetText("Disaster:"+GetDisasterName());


        currentTotalAnimals.SetText("Total Animals:" + simulation.GetTotalPopulation());
        chickenPopulation.SetText("Population:" + simulation.GetPopulation(new Chicken()));
        deerPopulation.SetText("Population:" + simulation.GetPopulation(new Deer()));
        dogPopulation.SetText("Population:" + simulation.GetPopulation(new Dog()));
        horsePopulation.SetText("Population:" + simulation.GetPopulation(new Horse()));
        kittyPopulation.SetText("Population:" + simulation.GetPopulation(new Kitty()));
        pinguinPopulation.SetText("Population:" + simulation.GetPopulation(new Pinguin()));
        tigerPopulation.SetText("Population:" + simulation.GetPopulation(new Tiger()));


    }


    // Função para reiniciar o tempo
    public void ResetTime()
    {
        currentDayProgress = 0f;
        currentDay = 1;
        UpdateTimeText();
    }
}