using UnityEngine;

public class SunlightController : MonoBehaviour
{
    public Light sunLight;  // A luz direcional (o sol)
    public double currentDayProgress = 0.0; // Progresso atual do dia (0 a 1)

    void Update()
    {
        // Ajuste a rotação da luz solar com base no progresso do dia
        AdjustSunPosition();

        // Ajuste a intensidade da luz com base no progresso do dia
        AdjustLightIntensity();
    }

    void AdjustSunPosition()
    {
        // Calculando a rotação do sol baseada no progresso do dia
        float sunRotation = (float)(currentDayProgress * 360f); // 360 graus para um ciclo completo de 24 horas

        // Ajustando a rotação da luz direcional para simular o movimento do sol
        sunLight.transform.rotation = Quaternion.Euler(sunRotation - 90f, 170f, 0); // -90 para começar no horizonte, 170 para um ângulo específico
    }

    void AdjustLightIntensity()
    {
        // Ajustando a intensidade da luz
        // Intensidade máxima durante o dia (meio-dia) e mínima à noite (meia-noite)
        sunLight.intensity = Mathf.Clamp01(1f - Mathf.Abs((float)currentDayProgress - 0.5f) * 2f);
    }
}
