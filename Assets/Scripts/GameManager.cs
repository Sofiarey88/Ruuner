using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject panelGameOver;

    public void GameOver()
    {
        panelGameOver.SetActive(true);
        Time.timeScale = 0f; // pausa el juego
    }
}