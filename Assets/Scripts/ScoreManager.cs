using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{


    public static ScoreManager instance;

    public int puntos = 0;
    public TextMeshProUGUI textoPuntos;

    void Awake()
    {
        instance = this;
    }

    public void SumarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarUI();
    }

    void ActualizarUI()
    {
        textoPuntos.text = "Puntos: " + puntos;
    }
}

