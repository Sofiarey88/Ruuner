using UnityEngine;

public class Punto : MonoBehaviour
{
    public int valor = 1;

    private Renderer rend;
    private Collider col;

    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.SumarPuntos(valor);
            Ocultar();
        }
    }

    public void Ocultar()
    {
        rend.enabled = false;
        col.enabled = false;
    }

    public void Mostrar()
    {
        rend.enabled = true;
        col.enabled = true;
    }

    public void Resetear()
    {
        Mostrar();
    }
}