using System.Collections.Generic;
using UnityEngine;

public class Seccion : MonoBehaviour
{
    public List<GameObject> obstaculos;

    public float speed = 8f;
    public float largo = 20f;

    private Vector3 posicionInicial;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        posicionInicial = transform.position;

        obstaculos = new List<GameObject>();

        foreach (Transform t in transform)
        {
            if (t.CompareTag("obstaculo"))
            {
                obstaculos.Add(t.gameObject);
            }
        }

        Randomm();
    }

    void FixedUpdate()
    {
        // Uso totalmente cualificado para evitar el conflicto con una clase llamada "Time" en el proyecto
        rb.MovePosition(rb.position + Vector3.back * speed * global::UnityEngine.Time.fixedDeltaTime);

        if (rb.position.z < posicionInicial.z - largo)
        {
            rb.position = posicionInicial;
            Randomm();
        }
    }

    public void Randomm()
    {
        foreach (GameObject obstaculo in obstaculos)
        {
            obstaculo.SetActive(false);
        }

        if (obstaculos.Count > 0)
        {
            int randomIndex = Random.Range(0, obstaculos.Count);
            obstaculos[randomIndex].SetActive(true);
        }
    }
}