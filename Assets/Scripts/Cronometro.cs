using TMPro;
using UnityEngine;

// Renombrada para evitar colisiones con UnityEngine.Time
public class GameTimer : MonoBehaviour
{
    public TextMeshProUGUI tiempoText;

    private float tiempo = 0f;
    private bool corriendo = true;

    void Update()
    {
        if (!corriendo) return;

        // Uso cualificado por seguridad
        tiempo += global::UnityEngine.Time.deltaTime;

        int minutos = Mathf.FloorToInt(tiempo / 60);
        int segundos = Mathf.FloorToInt(tiempo % 60);

        if (tiempoText != null)
            tiempoText.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

    public void DetenerTiempo()
    {
        corriendo = false;
    }
}