using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using Backend;
using Backend.Animals;
using Utils;

public class TimeController : MonoBehaviour
{
    [SerializeField] private Slider timeSlider;         // Referência ao Slider
    [SerializeField] private TextMeshProUGUI timeText;  // Referência ao texto do tempo
    [SerializeField] private TextMeshProUGUI toggleButtonText; // Referência ao texto do botão
    [SerializeField] private TextMeshProUGUI speedText; // Texto para mostrar a velocidade atual

     [SerializeField] private TextMeshProUGUI currentDayProgressText; // Texto para mostrar a fração de dia passado

    [SerializeField] private float baseDayDuration = 10f;  // Duração base de um dia em segundos (10 segundos)


    private DayOfWeek[] simulationDays;

    private Simulation simulation;


        AnimalSpawner animalSpawner;

    // Enum com todas as velocidades possíveis de tempo
    private enum Speed
    { 
        Pause = 0,
        x1 = 1,
        x2 = 2,
        x5 = 5,
        x10 = 10,
        x100 = 100,

        x200=200
    }

    [SerializeField] private Speed currentSpeed = Speed.x1;
    private float currentDayProgress = 0f;
    private int currentDay = 1;  // Começa no Dia 1

    

    void Start()
    {
        Debug.Log("Hello World!");
        
        // Configurações iniciais do slider
        if (timeSlider != null)
        {
            timeSlider.minValue = 0f;
            timeSlider.maxValue = 100f;  // Progresso do dia de 0 a 100 dias
        }

        simulation = new Simulation(100, 10, new Backend.Animals.Animal1());

        animalSpawner = new AnimalSpawner(new Backend.Animals.Animal1(), 100, new Vector3(0, 0, 0), new Vector3(1000, 1000, 10));
        animalSpawner.SpawnAnimals();

        UpdateTimeText();
        UpdateSpeedText();
    }

    void Update() //É chamada a cada frame
    {
        if (currentSpeed != Speed.Pause)
        {
            float timeBetweenFrames = Time.deltaTime;
            // Avança o progresso do dia
            currentDayProgress += (1/baseDayDuration)* timeBetweenFrames * (int)currentSpeed ;

            // Verifica se um dia foi completado
            if (currentDayProgress >= 1f)
            {
                currentDayProgress = 0f;
                // currentDay++;
                advanceDay();
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
        int maxSpeedIndex = Enum.GetValues(typeof(Speed)).Length - 1;

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
        if (speedText != null)
        {
            speedText.text = currentSpeed == Speed.Pause ? "Pause" : $"{(int)currentSpeed}x";
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

    private void advanceDay(){
        UnityEngine.Debug.Log("On this these day there were "+simulation.getNumOfAnimals() + "animals!");
        currentDay++;
        simulation.nextDay();
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

    private void UpdateCurrentDayProgressText(){
        if(currentDayProgressText!=null){
            currentDayProgressText.text = "Current Day progress:"+currentDayProgress;
        }

    }


    // Função para reiniciar o tempo
    public void ResetTime()
    {
        currentDayProgress = 0f;
        currentDay = 1;
        UpdateTimeText();
    }
}