using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public TextMeshProUGUI Title; // Arraste no Inspector ou inicialize no código.


    void Awake()
    {
        // Mensagem de erro ao instanciar o objeto
        Debug.LogError("i was constructed");
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
        
        // Thread.Sleep(1000);

        await Task.Delay(1000);
        Debug.Log("Preparado");
        // Descomente quando quiser carregar a cena:
        SceneManager.LoadScene("Mundo");
    }
}
